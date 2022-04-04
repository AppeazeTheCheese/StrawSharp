using System;
using System.Net.Http;
using StrawSharp.Responses;

namespace StrawSharp.Requests
{
    internal class GetPollRequest : BaseRequest<PollResponse>
    {
        private readonly string _pollId;

        protected override string Endpoint => $"polls/{_pollId}";
        internal override HttpMethod Method => HttpMethod.Get;
        internal override bool SerializeBody => false;

        internal GetPollRequest(string pollId)
        {
            if (string.IsNullOrWhiteSpace(pollId))
                throw new ArgumentException("Poll ID must be specified");

            _pollId = pollId;
        }
    }
}
