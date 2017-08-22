using Newtonsoft.Json;

namespace SwissQrClient.TransferObjects.RequestParameters.Stripe
{
    public class SubscribeParameter
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("plan")]
        public string Plan { get; set; }
    }
}
