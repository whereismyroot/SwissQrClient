using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace SwissQrClient.Requests.Base
{
    public abstract class RestClientRequestBase<TResponse> : IRestClientRequest<TResponse>
        where TResponse : class, new()
    {
        public abstract Method Method { get; }

        public abstract string Resource { get; }

        public abstract HttpStatusCode SuccessStatusCode { get; }

        public IRestRequest BuildRequest()
        {
            RestRequest request = new RestRequest(Resource, Method)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonNetSerializer()
            };
            
            request.AddHeader(Headers.ContentType, Constants.ApplicationJson);

            foreach (Parameter parameter in GetParameters())
            {
                if (parameter.Type == ParameterType.RequestBody)
                {
                    request.AddBody(parameter.Value);
                }
                else
                {
                    request.AddParameter(parameter);
                }
            }

            ConfigureRequest(request);

            return request;
        }

        protected virtual void ConfigureRequest(RestRequest request)
        {
        }

        protected abstract IEnumerable<Parameter> GetParameters();
    }
}
