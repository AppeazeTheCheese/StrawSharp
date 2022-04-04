using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StrawSharp.Models;
using StrawSharp.Requests;
using StrawSharp.Responses;

namespace StrawSharp
{
    public class StrawPollClient
    {
        private readonly string _apiKey = null;
        private static readonly HttpClient Client = new HttpClient();

        static StrawPollClient()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public static string GetPollUrl(string pollId) => $"https://strawpoll.com/polls/{pollId}";

        public StrawPollClient() { }

        public StrawPollClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<Poll> CreatePollAsync(Poll poll)
        {
            var request = new CreatePollRequest(poll);
            return (await SendRequestAsync(request)).Poll;
        }

        public async Task<Poll> GetPollAsync(string pollId)
        {
            var request = new GetPollRequest(pollId);
            return (await SendRequestAsync(request)).Poll;
        }

        private async Task<T> SendRequestAsync<T>(BaseRequest<T> request)
        {
            var message = new HttpRequestMessage
            {
                RequestUri = request.FullUrl,
                Method = request.Method,
            };
            if (_apiKey != null)
                message.Headers.Add("X-API-KEY", _apiKey);

            if (request.SerializeBody)
            {
                var content = request.Serialize();
                message.Content = new StringContent(content, Encoding.ASCII, "application/json");
            }

            var response = await Client.SendAsync(message);
            return await HandleResponseAsync<T>(response);
        }

        private static async Task<T> HandleResponseAsync<T>(HttpResponseMessage message)
        {
            var responseText = await message.Content.ReadAsStringAsync();
            if (!message.IsSuccessStatusCode)
                throw new WebException($"The StrawPoll server returned {message.StatusCode}: {responseText}");

            var resp = JsonSerializer.Deserialize<BaseResponse>(responseText);
            if (resp?.Success ?? false)
                return JsonSerializer.Deserialize<T>(responseText);

            throw new StrawPollException(JsonSerializer.Deserialize<ErrorResponse>(responseText));
        }
    }
}
