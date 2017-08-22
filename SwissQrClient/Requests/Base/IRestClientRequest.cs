using System.Net;
using RestSharp;

namespace SwissQrClient.Requests.Base
{
    public interface IRestClientRequest
    {
        HttpStatusCode SuccessStatusCode { get; }

        string Resource { get; }

        IRestRequest BuildRequest();
    }

    public interface IRestClientRequest<T> : IRestClientRequest
        where T : class, new()
    {
    }
}
