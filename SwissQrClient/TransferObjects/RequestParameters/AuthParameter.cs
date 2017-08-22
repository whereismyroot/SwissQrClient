using System;
using Newtonsoft.Json;

namespace SwissQrClient.TransferObjects.RequestParameters
{
    public class AuthParameter
    {
        public AuthParameter(string email, string password)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        [JsonProperty("email")]
        public string Email { get; }

        [JsonProperty("password")]
        public string Password { get; }
    }
}
