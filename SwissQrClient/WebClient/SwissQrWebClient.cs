using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using SwissQrClient.Requests;
using SwissQrClient.Requests.Base;
using SwissQrClient.Settings;
using SwissQrClient.TransferObjects;
using SwissQrClient.TransferObjects.RequestParameters;

namespace SwissQrClient.WebClient
{
    public class SwissQrWebClient : IWebClient
    {
        private readonly IEndpointSettings _apiEndpointSettings;

        public SwissQrWebClient(IEndpointSettings apiEndpointSettings)
        {
            _apiEndpointSettings = apiEndpointSettings;
        }

        public UserSimpleDto AuthenticatedUser { get; private set; }

        public string AuthToken { get; private set; }

        public bool IsAuthenticated => AuthenticatedUser != null && !string.IsNullOrEmpty(AuthToken);

        public async Task<Result<AuthResult>> RegisterUserAsync(RegisterUserDto dto)
        {
            var request = new RegisterUserRequest(dto);
            return await ExecuteAuthRequest(request);
        }
        public Result<AuthResult> RegisterUser(RegisterUserDto dto)
        {
            var request = new RegisterUserRequest(dto);
            return AsyncHelper.RunSync(() => ExecuteAuthRequest(request));
        }

        public async Task<Result<AuthResult>> AuthenticateAsync(AuthParameter parameter)
        {
            var request = new AuthenticateRequest(parameter);
            return await ExecuteAuthRequest(request);
        }

        public Result<AuthResult> Authenticate(AuthParameter parameter)
        {
            var request = new AuthenticateRequest(parameter);
            return AsyncHelper.RunSync(() => ExecuteAuthRequest(request));
        }

        public void ClearAuthenticationInfo()
        {
            AuthenticatedUser = null;
            AuthToken = null;
        }

        public Result<T> ExecuteApiRequest<T>(IRestClientRequest<T> request) where T : class, new()
        {
            return AsyncHelper.RunSync(() => ExecuteAsync(request, _apiEndpointSettings));
        }

        public Task<Result<T>> ExecuteApiRequestAsync<T>(IRestClientRequest<T> request)
            where T : class, new()
        {
            return ExecuteAsync(request, _apiEndpointSettings);
        }

        public Task ExecuteApiRequestAsync(IRestClientRequest request)
        {
            return ExecuteAsync(request, _apiEndpointSettings);
        }

        private async Task<Result<TResponse>> ExecuteAsync<TResponse>(IRestClientRequest<TResponse> request, IEndpointSettings settings, bool isV1 = true)
            where TResponse : class, new()
        {
            IRestResponse restResponse = await ExecuteRestRequestAsync(request, settings, isV1);

            if (restResponse.StatusCode == HttpStatusCode.InternalServerError)
            {
                return Result<TResponse>.Error(restResponse.StatusCode, restResponse.Content);
            }

            TResponse data;

            try
            {
                data = JsonConvert.DeserializeObject<TResponse>(restResponse.Content, new JsonSerializerSettings {Error = OnSerializeError});
            }
            catch (Exception ex)
            {
                return Result<TResponse>.Error(restResponse.StatusCode, restResponse.Content, ex);
            }

            return Result<TResponse>.Success(data);
        }
        
        private Task ExecuteAsync(IRestClientRequest request, IEndpointSettings settings)
        {
            return ExecuteRestRequestAsync(request, settings);
        }

        private async Task<IRestResponse> ExecuteRestRequestAsync(IRestClientRequest restClientRequest, IEndpointSettings settings, bool isV1 = true)
        {
            IRestRequest restRequest = restClientRequest.BuildRequest();

            string baseAddress = $"{settings.BaseAddress}/api{(isV1 ? "/v1" : "")}";

            int defaultTimeoutMiliseconds = settings.DefaultTimeoutSeconds * 1000;

            RestClient restClient = new RestClient(baseAddress)
            {
                Timeout = defaultTimeoutMiliseconds
            };

            if (isV1 && !string.IsNullOrEmpty(AuthToken))
            {
                restClient.AddDefaultHeader("Authorization", $"Bearer {AuthToken}");
            }

            IRestResponse restResponse = await restClient.ExecuteTaskAsync(restRequest);

            return restResponse;
        }

        private async Task<Result<AuthResult>> ExecuteAuthRequest(IRestClientRequest<AuthResult> request)
        {
            Result<AuthResult> result;

            IRestResponse restResponse = await ExecuteRestRequestAsync(request, _apiEndpointSettings, false);

            if (restResponse.StatusCode != request.SuccessStatusCode)
            {
                result = Result<AuthResult>.Error(
                    restResponse.StatusCode,
                    restResponse.Content);
            }
            else
            {
                AuthResult data = JsonConvert.DeserializeObject<AuthResult>(restResponse.Content);
                result = Result<AuthResult>.Success(data);
            }

            if (result.IsSuccess)
            {
                AuthToken = result.Data.Data.Token;
                AuthenticatedUser = result.Data.Data.User;
            }

            return result;
        }

        private void OnSerializeError(object sender, ErrorEventArgs e)
        {
            HashSet<string> ignoredFields = new HashSet<string>
            {
                "setting",
                "item"
            };
            // ignoring fields errors because they can be of defferent types
            if (ignoredFields.Contains(e.ErrorContext.Path.ToString().ToLower()))
            {
                e.ErrorContext.Handled = true;
            }
        }
    }
}
