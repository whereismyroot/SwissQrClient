using System.Collections.Generic;
using System.Net;
using RestSharp;
using SwissQrClient.Requests.Base;
using SwissQrClient.TransferObjects;
using SwissQrClient.TransferObjects.RequestParameters;

namespace SwissQrClient.Requests
{
    internal sealed class AuthenticateRequest : RestClientRequestBase<AuthResult>
    {
        private readonly AuthParameter _parameter;

        public AuthenticateRequest(AuthParameter parameter)
        {
            _parameter = parameter;
        }

        public override Method Method { get; } = Method.POST;

        public override string Resource { get; } = "auth/login";

        public override HttpStatusCode SuccessStatusCode { get; } = HttpStatusCode.OK;

        protected override IEnumerable<Parameter> GetParameters()
        {
            yield return new Parameter { Name = "data", Value = _parameter, Type = ParameterType.RequestBody };
        }
    }
}
