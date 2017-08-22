using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace SwissQrClient.WebClient
{
    public class Error
    {
        public Error(HttpStatusCode httpStatusCode, string responseContent, Exception exception)
        {
            HttpStatusCode = httpStatusCode;
            ResponseContent = responseContent;
            Exception = exception;
        }

        public Error()
        {
        }

        [JsonProperty("message")]
        public Dictionary<string, string[]> ErrorMessages { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonIgnore]
        public HttpStatusCode HttpStatusCode { get; }

        [JsonIgnore]
        public string ResponseContent { get; }

        [JsonIgnore]
        public Exception Exception { get; }
    }
}
