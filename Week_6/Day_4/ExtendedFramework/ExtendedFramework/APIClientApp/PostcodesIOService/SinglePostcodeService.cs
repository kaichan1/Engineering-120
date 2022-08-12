using APIClientApp.PostcodesIOService.DataHandling;
using APIClientApp.PostcodesIOService.HTTPManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APIClientApp.PostcodesIOService
{

        public class SinglePostcodeService
        {
            #region Properties
            public CallManager CallManager { get; set; }
            // a Newtonsoft object representing the json response
            public JObject Json_Response { get; set; }
            // the response DTO. Note, that it is a generic type, but we can specify the type of reponse we want. We will come back to this later!
            public DTO<SinglePostcodeResponse> SinglePostcodeDTO { get; set; }
            // the postcode used in this API request
            public string PostcodeSelected { get; set; }
            // the response content as a string
            public string PostcodeResponse { get; set; }
            #endregion

            public SinglePostcodeService()
            {
                CallManager = new CallManager();
                SinglePostcodeDTO = new DTO<SinglePostcodeResponse>();
            }
            /// <summary>
            /// defines and makes the API request, and stores the response
            /// </summary>
            /// <param name="postcode"></param>
            public async Task MakeRequestAsync(string postcode)
            {
                PostcodeSelected = postcode;
                // make request
                PostcodeResponse = await CallManager.MakeRequestAsync(Resource.Postcodes, postcode, Method.Get);
                // Parse JSON string into a JObject
                Json_Response = JObject.Parse(PostcodeResponse);
                // use DTO to convert JSON string to an object tree
                SinglePostcodeDTO.DeserializeResponse(PostcodeResponse);
            }

        public string GetHeaderValue(string name)
        {
            return CallManager.Response.Headers.Where(x => x.Name == name).Select(x => x.Value.ToString()).FirstOrDefault();
        }

        public string GetResponseContentType()
        {
            return CallManager.Response.ContentType;
        }

        public int CodeCount()
        {
            return Json_Response["result"]["codes"].Count();
        }
    }
    }
