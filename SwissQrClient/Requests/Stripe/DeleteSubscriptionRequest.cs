using System.Collections.Generic;
using System.Net;
using RestSharp;
using SwissQrClient.Requests.Base;
using SwissQrClient.WebClient;

namespace SwissQrClient.Requests.Stripe
{
    public sealed class DeleteSubscriptionRequest : RestClientRequestBase<ItemResult<object>>
    {
        public DeleteSubscriptionRequest()
        {
        }

        public override Method Method { get; } = Method.DELETE;

        public override string Resource { get; } = "stripe";

        public override HttpStatusCode SuccessStatusCode { get; } = HttpStatusCode.OK;

        protected override IEnumerable<Parameter> GetParameters()
        {
            yield break;
        }
    }
}
