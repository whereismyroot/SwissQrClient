using System.Collections.Generic;
using System.Net;
using RestSharp;
using SwissQrClient.Requests.Base;
using SwissQrClient.TransferObjects.RequestParameters;
using SwissQrClient.WebClient;

namespace SwissQrClient.Requests
{
    public sealed class GenerateQrRequest : RestClientRequestBase<ItemResult<string>>
    {
        private readonly string _type;
        private readonly string _output;
        private readonly string _lang;
        private readonly GenerateQrParameter _param;

        public GenerateQrRequest(string type, string output, string lang, GenerateQrParameter param)
        {
            _type = type;
            _output = output;
            _lang = lang;
            _param = param;
        }

        public override Method Method { get; } = Method.POST;

        public override string Resource { get; } = "qr/{type}";

        public override HttpStatusCode SuccessStatusCode { get; } = HttpStatusCode.OK;

        protected override IEnumerable<Parameter> GetParameters()
        {
            yield return new Parameter { Name = "type", Value = _type, Type = ParameterType.UrlSegment };
            yield return new Parameter { Name = "output", Value = _output, Type = ParameterType.QueryString };
            yield return new Parameter { Name = "lang", Value = _lang, Type = ParameterType.QueryString };
            yield return new Parameter { Name = "body", Value = _param, Type = ParameterType.RequestBody };
        }
    }
}
