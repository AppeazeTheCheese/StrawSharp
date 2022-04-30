using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StrawSharp.Models;
using StrawSharp.Responses;

namespace StrawSharp
{
    public class StrawPollClient
    {
        private readonly string _apiKey;
        private static readonly HttpClient Client = new HttpClient {BaseAddress = new Uri(ApiConstants.ApiBase)};

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

        #region Polls

        public async Task<PollListResponse> GetMyPollsAsync(int limit = 10, int page = 1)
        {
            var endpoint = $"{ApiConstants.Endpoints.MyPolls}?page={page}&limit={limit}";
            var method = HttpMethod.Get;

            var response = await SendRestRequestAsync<PollListResponse>(endpoint, method);
            return response;
        }

        public async Task<Poll> GetPollAsync(string pollId)
        {
            var endpoint = Path.Combine(ApiConstants.Endpoints.Polls, pollId);
            var method = HttpMethod.Get;

            var response = await SendRestRequestAsync<PollResponse>(endpoint, method);
            return response.Poll;
        }

        public async Task<Poll> CreatePollAsync(Poll poll)
        {
            var endpoint = ApiConstants.Endpoints.Polls;
            var method = HttpMethod.Post;

            var response = await SendRestRequestAsync<PollResponse>(endpoint, method, poll);
            return response.Poll;
        }

        public async Task<Poll> UpdatePollAsync(string pollId, Poll poll)
        {
            var endpoint = Path.Combine(ApiConstants.Endpoints.Polls, pollId);
            var method = HttpMethod.Put;

            var response = await SendRestRequestAsync<PollResponse>(endpoint, method, poll);
            return response.Poll;
        }

        public async Task<Poll> UpdatePollAsync(Poll poll)
        {
            if (string.IsNullOrWhiteSpace(poll.Id))
                throw new ArgumentException(
                    "The poll ID cannot be null to use this overload. Consider using UpdatePollAsync(pollId, poll) instead.");

            return await UpdatePollAsync(poll.Id, poll);
        }

        public async Task<MessageResponse> DeletePollAsync(string pollId)
        {
            var endpoint = Path.Combine(ApiConstants.Endpoints.Polls, pollId);
            var method = HttpMethod.Delete;

            return await SendRestRequestAsync<MessageResponse>(endpoint, method);
        }

        #endregion

        #region Media

        public async Task<PollMedia> UploadMediaAsync(string fileName, Stream fileStream)
        {
            var endpoint = ApiConstants.Endpoints.Media;

            fileStream.Seek(0, SeekOrigin.Begin);
            var streamContent = new StreamContent(fileStream);
            streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"file\"",
                FileName = $"\"{fileName ?? "file"}\""
            };

            var formData = new MultipartFormDataContent
            {
                streamContent
            };

            var response = await PostHttpContentAsync<MediaResponse>(formData, endpoint);
            return response.Media;
        }

        public async Task<PollMedia> UploadMediaAsync(string fileName, byte[] content)
        {
            return await UploadMediaAsync(fileName, new MemoryStream(content));
        }

        #endregion

        #region Request Handling

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


        private static async Task<T> HandleResponseAsync<T>(HttpResponseMessage message)
        {
            var responseText = await message.Content.ReadAsStringAsync();
            if (!message.IsSuccessStatusCode)
                throw new WebException($"The StrawPoll server returned code {message.StatusCode}: {responseText}");

            var resp = JsonSerializer.Deserialize<BaseResponse>(responseText);
            if (typeof(T) == typeof(MessageResponse) || (resp?.Success ?? false)) // Don't throw an error if a MessageResponse is the expected type
                return JsonSerializer.Deserialize<T>(responseText);

            throw new StrawPollException(JsonSerializer.Deserialize<MessageResponse>(responseText));
        }

        #endregion
    }
}
