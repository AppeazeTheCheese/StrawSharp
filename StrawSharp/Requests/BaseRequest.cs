using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace StrawSharp.Requests
{
    [Serializable]
    public abstract class BaseRequest<T>
    {
        [JsonIgnore]
        private const string BaseUrl = "https://api.strawpoll.com/v2";

        [JsonIgnore]
        protected abstract string Endpoint { get; }

        [JsonIgnore] 
        internal abstract HttpMethod Method { get; }

        [JsonIgnore]
        internal abstract bool SerializeBody { get; }

        [JsonIgnore]
        internal Uri FullUrl => new Uri(Path.Combine(BaseUrl, Endpoint));

        internal virtual string Serialize()
        {
            return InternalSerialize(this);
        }

        protected string InternalSerialize(object request)
        {
            return JsonSerializer.Serialize(request);
        }

    }
}
