using System;
using Newtonsoft.Json;

namespace SwissQrClient.TransferObjects.RequestParameters
{
    public class GenerateQrParameter
    {
        public GenerateQrParameter(
            string level,
            string account,
            string crName,
            string crPostalCode,
            string crCity,
            string crCountry)
        {
            Level = level;

            Data = new QrCodeParameters
            {
                Account = account,
                CrName = crName,
                CrPostalCode = crPostalCode,
                CrCity = crCity,
                CrCountry = crCountry
            };

            Include = new QrInclude()
            {
                Ud = true
            };
        }

        [JsonProperty("size")]
        public int? Size { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("data")]
        public QrCodeParameters Data { get; set; }

        [JsonProperty("mergeSize")]
        public double? MergeSize { get; set; }

        [JsonProperty("include")]
        public QrInclude Include { get; set; }
    }

    public class QrCodeParameters
    {
        [JsonProperty("qr_type")]
        public string QrType { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("coding_type")]
        public string CodingType { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("cr_name")]
        public string CrName { get; set; }

        [JsonProperty("cr_street")]
        public string CrStreet { get; set; }

        [JsonProperty("cr_house_number")]
        public string CrHouseNumber { get; set; }

        [JsonProperty("cr_postal_code")]
        public string CrPostalCode { get; set; }

        [JsonProperty("cr_city")]
        public string CrCity { get; set; }

        [JsonProperty("cr_country")]
        public string CrCountry { get; set; }

        [JsonProperty("ucr_name")]
        public string UcrName { get; set; }

        [JsonProperty("ucr_street")]
        public string UcrStreet { get; set; }

        [JsonProperty("ucr_house_number")]
        public string UcrHouseNumber { get; set; }

        [JsonProperty("ucr_postal_code")]
        public string UcrPostalCode { get; set; }

        [JsonProperty("ucr_city")]
        public string UcrCity { get; set; }

        [JsonProperty("ucr_country")]
        public string UcrCountry { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("additional_information")]
        public string AdditionalInformation { get; set; }

        [JsonProperty("ud_name")]
        public string UdName { get; set; }

        [JsonProperty("ud_street")]
        public string UdStreet { get; set; }

        [JsonProperty("ud_house_number")]
        public string UdHouseNumber { get; set; }

        [JsonProperty("ud_postal_code")]
        public string UdPostalCode { get; set; }

        [JsonProperty("ud_city")]
        public string UdCity { get; set; }

        [JsonProperty("ud_country")]
        public string UdCountry { get; set; }

        [JsonProperty("due_date")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("amount")]
        public int? Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("reference_type")]
        public string ReferenceType { get; set; }
    }

    public class QrInclude
    {
        [JsonProperty("ucr")]
        public bool Ucr { get; set; }

        [JsonProperty("ud")]
        public bool Ud { get; set; }
    }
}
