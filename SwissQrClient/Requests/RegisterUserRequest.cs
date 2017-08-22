using System.Collections.Generic;
using System.Net;
using RestSharp;
using SwissQrClient.Requests.Base;
using SwissQrClient.TransferObjects;
using SwissQrClient.TransferObjects.RequestParameters;

namespace SwissQrClient.Requests
{
    public sealed class RegisterUserRequest : RestClientRequestBase<AuthResult>
    {
        private readonly RegisterUserDto _dto;

        public RegisterUserRequest(RegisterUserDto dto)
        {
            _dto = dto;
        }

        public override Method Method { get; } = Method.POST;

        public override string Resource { get; } = "auth/register";

        public override HttpStatusCode SuccessStatusCode { get; } = HttpStatusCode.OK;

        protected override IEnumerable<Parameter> GetParameters()
        {
            yield return new Parameter { Name = "dto", Value = _dto, Type = ParameterType.RequestBody };
        }
    }
}
