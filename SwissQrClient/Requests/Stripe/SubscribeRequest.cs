using System.Collections.Generic;
using System.Net;
using RestSharp;
using SwissQrClient.Requests.Base;
using SwissQrClient.TransferObjects.RequestParameters.Stripe;
using SwissQrClient.WebClient;

namespace SwissQrClient.Requests.Stripe
{
    public sealed class SubscribeRequest : RestClientRequestBase<ItemResult<string>>
    {
        private readonly SubscribeParameter _param;

        public SubscribeRequest(SubscribeParameter param)
        {
            _param = param;
        }

        public override Method Method { get; } = Method.POST;

        public override string Resource { get; } = "stripe";

        public override HttpStatusCode SuccessStatusCode { get; } = HttpStatusCode.OK;

        protected override IEnumerable<Parameter> GetParameters()
        {
            yield return new Parameter { Name = "body", Value = _param, Type = ParameterType.RequestBody };
        }
    }
}
