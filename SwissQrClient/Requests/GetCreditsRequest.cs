using System.Collections.Generic;
using System.Net;
using RestSharp;
using SwissQrClient.Requests.Base;
using SwissQrClient.WebClient;

namespace SwissQrClient.Requests
{
    public sealed class GetCreditsRequest : RestClientRequestBase<ItemResult<int>>
    {
        public override Method Method { get; } = Method.GET;

        public override string Resource { get; } = "credits";

        public override HttpStatusCode SuccessStatusCode { get; } = HttpStatusCode.OK;

        protected override IEnumerable<Parameter> GetParameters()
        {
            yield break;
        }
    }
}
