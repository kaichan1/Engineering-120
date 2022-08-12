using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.OutcodeServicesTests
{
    internal class WhenTheSingleOutcodeServiceIsCalled_WithValidOutcode
    {
        SingleOutcodeService _singleOutcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _singleOutcodeService = new SingleOutcodeService();
            await _singleOutcodeService.MakesRequestAsync("RG1");
        }

        [Test]
        public void StatusIs200_InJsonResponse()
        {
            Assert.That(_singleOutcodeService.ResponseContent["status"].ToString(), Is.EqualTo("200"));
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_singleOutcodeService.GetStatusCode, Is.EqualTo(200));
        }

        [Test]
        public void ObjectStatusIs200()
        {
            Assert.That(_singleOutcodeService.ResponseObject.status, Is.EqualTo(200));
        }

        [Test]
        public void StatusInResponseHeader_SameAsResponseBody()
        {
            Assert.That(_singleOutcodeService.GetStatusCode(), Is.EqualTo(_singleOutcodeService.ResponseObject.status));
        }

        [Test]
        public void CorrectOutcodeIsReturned()
        {
            var result = _singleOutcodeService.ResponseContent["result"]["outcode"].ToString();
            Assert.That(result, Is.EqualTo("RG1"));
        }

        [Test]
        public void AdminDistrict_IsReading()
        {
            Assert.That(_singleOutcodeService.ResponseObject.result.admin_district[1], Is.EqualTo("Reading"));
        } 
    }
}
