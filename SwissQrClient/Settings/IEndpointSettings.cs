namespace SwissQrClient.Settings
{
    public interface IEndpointSettings
    {
        string BaseAddress { get; }

        int DefaultTimeoutSeconds { get; }
    }
}
