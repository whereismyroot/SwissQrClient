using System.Collections.Generic;
using System.Net;
using RestSharp;
using SwissQrClient.Requests.Base;
using SwissQrClient.WebClient;

namespace SwissQrClient.Requests.Stripe
{
    public sealed class CheckSubscriptionRequest : RestClientRequestBase<ItemResult<object>>
    {
        public override Method Method { get; } = Method.GET;

        public override string Resource { get; } = "stripe";

        public override HttpStatusCode SuccessStatusCode { get; } = HttpStatusCode.OK;

        protected override IEnumerable<Parameter> GetParameters()
        {
            yield break;
        }
    }
}
