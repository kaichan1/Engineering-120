using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.SingleOutcodeServiceTests
{
    [Category("Happy Path")]

    public class WhenTheSingleOutcodeServiceIsCalled_WithValidPostcode
    {
        readonly SingleOutcodeService _singleOutcodeService = new SingleOutcodeService();

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            await _singleOutcodeService.MakeRequestAsync( "B76");
        }
        [Test]
        public void StatusIs200_InJsonResponseBody()
        {
            Assert.That(_singleOutcodeService.Json_Response["status"].ToString(), Is.EqualTo("200"));
        }
        public void StatusIs200()
        {
            Assert.That((int)_singleOutcodeService.CallManager.Response.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void ObjectStatusIs200()
        {
            Assert.That(_singleOutcodeService.OutcodeDTO.Response.status, Is.EqualTo(200));
        }

        [Test]
        public void AdminDistrictIsBirmingham_ForOutcodeB76_UsingJObject()
        {
            Assert.That(_singleOutcodeService.Json_Response["result"]["admin_district"][0].ToString(), Is.EqualTo("Birmingham"));
        }

        [Test]
        public void AdminDistrictIsBirmingham_ForOutcodeB76_usingObject()
        {
            Assert.That(_singleOutcodeService.OutcodeDTO.Response.result.admin_district[0], Is.EqualTo("Birmingham"));
        }

    }
}
