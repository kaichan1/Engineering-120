using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.BulkPostcodeServiceTests
{
    [Category("Happy Path")]
    public class WhenTheBulkPostCodeServiceIsCalled_WithValidPostcodes
    {
        readonly BulkPostcodeService _bulkPostcodeService = new BulkPostcodeService();

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            await _bulkPostcodeService.MakeRequestAsync("OX49 5NU, M32 0JG, NE30 1DP");
        }

        [Test]
        public void StatusIs200_InJsonResponseBody()
        {
            Assert.That(_bulkPostcodeService.Json_Response["status"].ToString(), Is.EqualTo("200"));

        }

        public void StatusIs200()
        {
            Assert.That((int)_bulkPostcodeService.CallManager.Response.StatusCode, Is.EqualTo(200));
        }
        [Test]
        public void ObjectStatusIs200()
        {
            Assert.That(_bulkPostcodeService.BulkpostcodeDTO.Response.Status, Is.EqualTo(200));
        }

        [Test]
        public void RegionForOX495NUIsCorrect()
        {
            var selectedLocation = _bulkPostcodeService.BulkpostcodeDTO.Response.result.Where(x => x.query == "OX49 5NU").FirstOrDefault();
            Assert.That(selectedLocation.result.region, Is.EqualTo("South East"));
        }

    }
}
