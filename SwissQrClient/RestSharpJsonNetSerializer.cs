using System.IO;
using Newtonsoft.Json;
using RestSharp.Serializers;

namespace SwissQrClient
{
    public sealed class RestSharpJsonNetSerializer : ISerializer
    {
        private readonly Newtonsoft.Json.JsonSerializer _serializer;

        public RestSharpJsonNetSerializer()
        {
            ContentType = Constants.ApplicationJson;
            _serializer = new Newtonsoft.Json.JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include
            };
        }

        public RestSharpJsonNetSerializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            ContentType = Constants.ApplicationJson;
            this._serializer = serializer;
        }

        public string ContentType { get; set; }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string Serialize(object obj)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';

                    _serializer.Serialize(jsonTextWriter, obj);

                    string result = stringWriter.ToString();
                    return result;
                }
            }
        }
    }
}
