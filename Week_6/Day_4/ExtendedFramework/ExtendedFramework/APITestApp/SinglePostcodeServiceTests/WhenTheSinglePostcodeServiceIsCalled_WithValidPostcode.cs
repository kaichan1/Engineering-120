
namespace APITestApp.SinglePostcodeServiceTests
{
    [Category("Happy Path")]

    public class WhenTheSinglePostcodeServiceIsCalled_WithValidPostcode
    {

        SinglePostcodeService _singlePostcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _singlePostcodeService = new SinglePostcodeService();
            await _singlePostcodeService.MakeRequestAsync("EC2Y 5AS");
        }

        [Test]
        public void StatusIs200_InJsonResponseBody()
        {
            Assert.That(_singlePostcodeService.Json_Response["status"].ToString(), Is.EqualTo("200"));
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That((int)_singlePostcodeService.CallManager.Response.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void ObjectStatusIs200()
        {
            Assert.That(_singlePostcodeService.SinglePostcodeDTO.Response.status, Is.EqualTo(200));

        }

        [Test]
        public void StatusInResponseHeader_SameAsStatusInResponseBody()
        {
            Assert.That((int)_singlePostcodeService.CallManager.Response.StatusCode, Is.EqualTo(_singlePostcodeService.SinglePostcodeDTO.Response.status));
        }

        [Test]
        public void AdminDistrict_IsCityOfLondon()
        {
            Assert.That(_singlePostcodeService.SinglePostcodeDTO.Response.result.admin_district, Is.EqualTo("City of London"));
        }

        [Test]
        public void CorrectPostcodeIsReturned()
        {
            var result = _singlePostcodeService.Json_Response["result"]["postcode"].ToString();
            Assert.That(result, Is.EqualTo("EC2Y 5AS"));
        }

        [Test]
        public void ContentType_IsJson()
        {
            Assert.That(_singlePostcodeService.GetResponseContentType(), Is.EqualTo("application/json"));
        }
        [Test]
        public void ConnectionIsKeepAlive()
        {
            Assert.That(_singlePostcodeService.GetHeaderValue("Connection"), Is.EqualTo("keep-alive"));
        }

        [Test]
        public void NumberOfCodes_IsCorrect()
        {
            Assert.That(_singlePostcodeService.CodeCount(), Is.EqualTo(12));
        }
    }


}
