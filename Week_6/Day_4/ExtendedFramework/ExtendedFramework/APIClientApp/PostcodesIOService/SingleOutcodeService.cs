using APIClientApp.PostcodesIOService.DataHandling;
using APIClientApp.PostcodesIOService.HTTPManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace APIClientApp.PostcodesIOService
{
    public class SingleOutcodeService
    {
        #region Properties
        public CallManager CallManager { get; set; }
        // a Newtonsoft object representing the json response
        public JObject Json_Response { get; set; }
        // the response DTO. Note, that it is a generic type, but we can specify the type of reponse we want. We will come back to this next!
        public DTO<SingleOutcodeResponse> OutcodeDTO { get; set; }
        // the response content as a string
        public string OutcodeResponse { get; set; }
        #endregion

        // constructor - creates the RestClient object
        public SingleOutcodeService()
        {
            CallManager = new CallManager();
            OutcodeDTO = new DTO<SingleOutcodeResponse>();
        }

        // method that defines and makes the API request, and stores the responses
        public async Task MakeRequestAsync(string outcode)
        {

            OutcodeResponse = await CallManager.MakeRequestAsync(Resource.Outcodes, outcode, Method.Get);
            // Parse JSON string into a JObject
            Json_Response = JObject.Parse(OutcodeResponse);
            // use DTO to convert JSON string to an object tree
            OutcodeDTO.DeserializeResponse(OutcodeResponse);

        }
    }
}