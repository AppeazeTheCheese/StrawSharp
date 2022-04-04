using System;
using System.Collections.Generic;
using System.Text;
using StrawSharp.Responses;

namespace StrawSharp
{
    public class StrawPollException : Exception
    {
        internal StrawPollException(ErrorResponse response) : base(response.Message)
        {

        }
    }
}
