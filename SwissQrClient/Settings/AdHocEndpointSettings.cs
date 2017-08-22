namespace SwissQrClient.Settings
{
    public class AdHocEndpointSettings : IEndpointSettings
    {
        public AdHocEndpointSettings(string baseAddress, int defaultTimeoutSeconds)
        {
            BaseAddress = baseAddress;
            DefaultTimeoutSeconds = defaultTimeoutSeconds;
        }

        public string BaseAddress { get; }

        public int DefaultTimeoutSeconds { get; }
    }
}
