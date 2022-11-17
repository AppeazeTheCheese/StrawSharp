using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using StrawSharp.Models.PollModels;
using StrawSharp.Models.ResponseModels;

namespace StrawSharp
{
    public class StrawPollClient
    {
        private readonly string _apiKey;
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri(ApiConstants.ApiBase) };

        public static string GetPollUrl(string pollId) => $"https://strawpoll.com/polls/{pollId}";

        static StrawPollClient()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public StrawPollClient() { }

        public StrawPollClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<PollListResponse> GetMyPollsAsync(int limit = 10, int page = 1)
        {
            var endpoint = $"{ApiConstants.Endpoints.MyPolls}?page={page}&limit={limit}";
            var method = HttpMethod.Get;

            var response = await SendRestRequestAsync<PollListResponse>(endpoint, method);
            return response;
        }

        public async Task<Poll> GetPollAsync(string pollId)
        {
            var endpoint = $"{ApiConstants.Endpoints.Polls}/{pollId}";
            var method = HttpMethod.Get;

            var response = await SendRestRequestAsync<Poll>(endpoint, method);
            return response;
        }

        public async Task<Poll> CreatePollAsync(Poll poll)
        {
            var endpoint = ApiConstants.Endpoints.Polls;
            var method = HttpMethod.Post;

            var response = await SendRestRequestAsync<Poll>(endpoint, method, poll);
            return response;
        }

        public async Task<Poll> UpdatePollAsync(Poll poll)
        {
            if (string.IsNullOrWhiteSpace(poll.Id))
                throw new ArgumentException(
                    "The poll ID cannot be null to use this overload. Consider using UpdatePollAsync(pollId, poll) instead.");

            return await UpdatePollAsync(poll.Id, poll);
        }
        
        public async Task<Poll> UpdatePollAsync(string pollId, Poll poll)
        {
            var endpoint = $"{ApiConstants.Endpoints.Polls}/{pollId}";
            var method = HttpMethod.Put;

            var response = await SendRestRequestAsync<Poll>(endpoint, method, poll);
            return response;
        }

        public async Task DeletePollAsync(string pollId)
        {
            var endpoint = $"{ApiConstants.Endpoints.Polls}/{pollId}";
            var method = HttpMethod.Delete;

            await SendRestRequestAsync(endpoint, method);
        }

        public async Task<PollMedia> UploadMediaAsync(string fileName, byte[] content)
        {
            return await UploadMediaAsync(fileName, new MemoryStream(content));
        }
        
        public async Task<PollMedia> UploadMediaAsync(string fileName, Stream fileStream)
        {
            var endpoint = ApiConstants.Endpoints.Upload;

            fileStream.Seek(0, SeekOrigin.Begin);
            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"file\"",
                FileName = $"\"{fileName ?? "file"}\""
            };

            var formData = new MultipartFormDataContent
            {
                fileContent,
            };

            var response = await PostHttpContentAsync<PollMedia>(formData, endpoint);
            return response;
        }

        private async Task SendRestRequestAsync(string endpoint, HttpMethod method, object data = null)
        {
            var message = new HttpRequestMessage
            {
                RequestUri = new Uri(endpoint, UriKind.Relative),
                Method = method
            };

            if (_apiKey != null)
                message.Headers.Add("X-API-KEY", _apiKey);

            if (data != null)
            {
                var content = JsonSerializer.Serialize(data);
                message.Content = new StringContent(content, Encoding.ASCII, "application/json");
            }

            var resp = await Client.SendAsync(message);
            await HandleResponseAsync(resp);
        }

        private async Task<T> SendRestRequestAsync<T>(string endpoint, HttpMethod method, object data = null)
        {
            var message = new HttpRequestMessage
            {
                RequestUri = new Uri(endpoint, UriKind.Relative),
                Method = method
            };

            if (_apiKey != null)
                message.Headers.Add("X-API-KEY", _apiKey);

            if (data != null)
            {
                var content = JsonSerializer.Serialize(data);
                message.Content = new StringContent(content, Encoding.ASCII, "application/json");
            }

            var response = await Client.SendAsync(message);
            return await HandleResponseAsync<T>(response);
        }

        private async Task<T> PostHttpContentAsync<T>(HttpContent content, string endpoint)
        {
            if (_apiKey != null)
                content.Headers.Add("X-API-KEY", _apiKey);

            var response = await Client.PostAsync(endpoint, content);
            return await HandleResponseAsync<T>(response);
        }

        private static async Task HandleResponseAsync(HttpResponseMessage message)
        {
            var responseText = await message.Content.ReadAsStringAsync();
            if (!message.IsSuccessStatusCode)
            {
                var response = JsonSerializer.Deserialize<ErrorResponse>(responseText);
                throw new StrawPollException(message.StatusCode, response);
            }
        }

        private static async Task<T> HandleResponseAsync<T>(HttpResponseMessage message)
        {
            var responseText = await message.Content.ReadAsStringAsync();
            if (!message.IsSuccessStatusCode)
            {
                var response = JsonNode.Parse(responseText)["error"].Deserialize<ErrorResponse>();
                throw new StrawPollException(message.StatusCode, response);
            }

            return JsonSerializer.Deserialize<T>(responseText);
        }
    }
}
