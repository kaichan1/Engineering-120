using APIClientApp.PostcodesIOService.DataHandling;
using APIClientApp.PostcodesIOService.HTTPManager;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace APIClientApp.PostcodesIOService
{
    public class BulkPostcodeService
    {
        #region Properties
        public CallManager CallManager { get; set; }
        // a Newtonsoft object representing the json response
        public JObject Json_Response { get; set; }
        // the response DTO. Note, that it is a generic type, but we can specify the type of reponse we want. We will come back to this next!
        public DTO<BulkPostcodeResponse> BulkpostcodeDTO { get; set; }

        // the response content as a string
        public string BulkPostcodesResponse { get; set; }


        #endregion
        // constructor - creates the RestClient object
        public BulkPostcodeService()
        {
            CallManager = new CallManager();
            BulkpostcodeDTO = new DTO<BulkPostcodeResponse>();
        }

        // method that defines and makes the API request, and stores the responses
        /// <summary>
        /// defines and makes the API request, and stores the response
        /// </summary>
        /// <param name="postcodes"></param>
        public async Task MakeRequestAsync(string postcodes)
        {
            // make request
            BulkPostcodesResponse = await CallManager.MakeRequestAsync(Resource.Postcodes, postcodes, RestSharp.Method.Post);
            // Parse JSON string into a JObject
            Json_Response = JObject.Parse(BulkPostcodesResponse);
            // use DTO to convert JSON string to an object tree
            BulkpostcodeDTO.DeserializeResponse(BulkPostcodesResponse);
        }
    }
}