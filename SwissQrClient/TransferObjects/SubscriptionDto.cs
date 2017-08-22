using System;
using Newtonsoft.Json;

namespace SwissQrClient.TransferObjects
{
    public class SubscriptionDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("credits")]
        public int Credits { get; set; }

        [JsonProperty("stripe_id")]
        public string StripeId { get; set; }

        [JsonProperty("stripe_plan")]
        public string StripePlan { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("trial_ends_at")]
        public DateTime? TrialEndsAt { get; set; }

        [JsonProperty("ends_at")]
        public DateTime? EndsAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
