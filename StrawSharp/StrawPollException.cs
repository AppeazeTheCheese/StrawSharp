using System;
using StrawSharp.Responses;

namespace StrawSharp
{
    public class StrawPollException : Exception
    {
        internal StrawPollException(MessageResponse response) : base(response.Message)
        {

        }
    }
}
