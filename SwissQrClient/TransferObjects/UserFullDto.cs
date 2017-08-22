using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwissQrClient.TransferObjects
{
    public class UserFullDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("stripe_id")]
        public string StripeId { get; set; }

        [JsonProperty("card_brand")]
        public string CardBrand { get; set; }

        [JsonProperty("card_last_four")]
        public string CardLastFour { get; set; }

        [JsonProperty("trial_ends_at")]
        public DateTime? TrialEndsAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("codes")]
        public List<QrCodeSimpleDto> Codes { get; set; }

        [JsonProperty("get_subscription")]
        public SubscriptionDto Subscription { get; set; }
    }
}
