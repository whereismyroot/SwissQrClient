using System.Threading.Tasks;
using SwissQrClient.Requests.Base;
using SwissQrClient.TransferObjects;
using SwissQrClient.TransferObjects.RequestParameters;

namespace SwissQrClient.WebClient
{
    public interface IWebClient
    {
        UserSimpleDto AuthenticatedUser { get; }

        bool IsAuthenticated { get; }

        Task<Result<AuthResult>> RegisterUserAsync(RegisterUserDto dto);

        Result<AuthResult> RegisterUser(RegisterUserDto dto);

        Task<Result<AuthResult>> AuthenticateAsync(AuthParameter parameter);

        Result<AuthResult> Authenticate(AuthParameter parameter);

        void ClearAuthenticationInfo();

        Result<T> ExecuteApiRequest<T>(IRestClientRequest<T> request)
            where T : class, new();

        Task<Result<T>> ExecuteApiRequestAsync<T>(IRestClientRequest<T> request)
            where T : class, new();

        Task ExecuteApiRequestAsync(IRestClientRequest request);
    }
}
