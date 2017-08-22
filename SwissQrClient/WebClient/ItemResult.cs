using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwissQrClient.WebClient
{
    public class ItemResult<T>
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("item")]
        public T Item { get; set; }

        [JsonProperty("setting")]
        public Dictionary<string, object> Settings { get; set; }

        public bool IsSuccess => string.Equals(Status, "ok", System.StringComparison.InvariantCultureIgnoreCase);
    }
}
