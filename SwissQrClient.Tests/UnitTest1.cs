using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwissQrClient.Dictionaries;
using SwissQrClient.Dictionaries.QrGeneration;
using SwissQrClient.Requests;
using SwissQrClient.Settings;
using SwissQrClient.TransferObjects.RequestParameters;
using SwissQrClient.WebClient;

namespace SwissQrClient.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var client = new SwissQrWebClient(new AdHocEndpointSettings("http://stage.qrcoderechnung.ch", 60));
            var registerDto = new RegisterUserDto()
            {
                Email = "test1@test.test",
                Name = "Test user name",
                Password = "12345678",
                PasswordConfirmation = "12345678"
            };

            //Result<AuthResult> result = client.RegisterUser(registerDto);
            //Result<AuthResult> result = await client.RegisterUserAsync(registerDto);
            var authResult = await client.AuthenticateAsync(new AuthParameter("test@test.test", "12345678"));

            //var credits = await client.ExecuteApiRequestAsync(new GetCreditsRequest());
            //var user = await client.ExecuteApiRequestAsync(new GetAuthenticatedUserRequest());
            var param = new GenerateQrParameter(
                QrCodeQualityLevels.Medium,
                "CH4431999123000889012",
                "Test CrName",
                "24343535",
                "Dnipro",
                "Ukraine"
                )
            {
                MergeSize = 0.1,
                Size = 300
            };

            param.Data.QrType = "SPC";
            param.Data.Version = "0100";
            param.Data.CodingType = "1";
            param.Data.Amount = 1;
            param.Data.ReferenceType = "QRR";
            param.Data.Currency = "CHF";

            var qrResult = await client.ExecuteApiRequestAsync(new GenerateQrRequest(
                QrCodeTypes.Jpeg,
                QrCodeOutputs.Link,
                Languages.German, 
                param));
        }
    }
}
