using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.BulkPostcodeServicesTests
{
    public class WhenTheBulkPostcodeServiceIsCalled_WithValidPostcode
    {
        BulkPostcodeService _bulkPostcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _bulkPostcodeService = new BulkPostcodeService();
            var postcodes = new
            {
                Postcodes = new string[] { "PR3 0SG", "M45 6GN", "EX165BL" }
            };
            await _bulkPostcodeService.MakesRequestAsync(postcodes);
        }

        [Test]
        public void StatusIs200_InJsonResponse()
        {
            Assert.That(_bulkPostcodeService.ResponseContent["status"].ToString(), Is.EqualTo("200"));
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_bulkPostcodeService.GetStatusCode, Is.EqualTo(200));
        }

        [Test]
        public void ObjectStatusIs200()
        {
            Assert.That(_bulkPostcodeService.ResponseObject.Status, Is.EqualTo(200));
        }

        [Test]
        public void StatusInResponseHeader_SameAsResponseBody()
        {
            Assert.That(_bulkPostcodeService.GetStatusCode(), Is.EqualTo(_bulkPostcodeService.ResponseObject.Status));
        }

        [Test]
        public void CorrectRegionForPR30SGIsReturned()
        {
            var result = _bulkPostcodeService.ResponseContent["result"][0]["result"]["region"].ToString();
            Assert.That(result, Is.EqualTo("North West"));
        }

        //[Test]
        //public void CorrectAdminDistrictForM456GNIsReturned()
        //{
        //    Assert.That(_bulkPostcodeService.ResponseObject.result.Where(q => q.query == "M45 6GN").
        //        FirstOrDefault().result.admin_district, Is.EqualTo("Bury"));
        //}

        [TestCaseSource("AddCases")]
        public void CorrectAdminDistrictIsReturned(string postcode, string expectedResult)
        {
            var result = _bulkPostcodeService.ResponseObject.result.Where(q => q.query == postcode).
                FirstOrDefault().result.admin_district;
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        private static string[][] AddCases =
        {
            new string[] { "M45 6GN", "Bury" },
            new string[] { "PR3 0SG", "Wyre" },
            new string[] { "EX165BL", "Mid Devon" }
        };
    }
}
