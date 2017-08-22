using System.Configuration;

namespace SwissQrClient.Settings
{
    public class ConfigEndpointSettings : IEndpointSettings
    {
        public string BaseAddress => ConfigurationManager.AppSettings["SwissQrBaseAddress"];

        public int DefaultTimeoutSeconds => int.Parse(ConfigurationManager.AppSettings["SwissQrDefaultTimeoutSeconds"]);
    }
}
