using System;
using System.Net;
using StrawSharp.Models.ResponseModels;

namespace StrawSharp
{
    public class StrawPollException : Exception
    {
        internal StrawPollException(HttpStatusCode status, ErrorResponse response) : base($"{(int)status} {status}: {response.Message}")
        {

        }
    }
}
