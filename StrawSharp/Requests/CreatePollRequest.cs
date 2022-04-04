using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json.Serialization;
using StrawSharp.Models;
using StrawSharp.Responses;

namespace StrawSharp.Requests
{
    internal class CreatePollRequest : BaseRequest<PollResponse>
    {
        protected override string Endpoint => "polls";
        internal override HttpMethod Method => HttpMethod.Post;
        internal override bool SerializeBody => true;

        internal Poll Poll;

        internal CreatePollRequest(Poll poll)
        {
            Poll = poll;
        }

        internal override string Serialize()
        {
            return InternalSerialize(Poll);
        }
    }
}
