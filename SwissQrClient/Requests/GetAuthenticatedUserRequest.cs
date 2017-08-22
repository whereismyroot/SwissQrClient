using System.Collections.Generic;
using System.Net;
using RestSharp;
using SwissQrClient.Requests.Base;
using SwissQrClient.TransferObjects;
using SwissQrClient.WebClient;

namespace SwissQrClient.Requests
{
    public sealed class GetAuthenticatedUserRequest : RestClientRequestBase<ItemResult<UserFullDto>>
    {
        public override Method Method { get; } = Method.GET;

        public override string Resource { get; } = "user";

        public override HttpStatusCode SuccessStatusCode { get; } = HttpStatusCode.OK;

        protected override IEnumerable<Parameter> GetParameters()
        {
            yield break;
        }
    }
}
