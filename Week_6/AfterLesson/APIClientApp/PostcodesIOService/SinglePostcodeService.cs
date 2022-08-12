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
        public JObject Json_Response { get; set; }
        public DTO<SinglePostcodeResponse> SinglePostcodeDTO { get; set; }
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
        /// <returns></returns>

        public async Task MakesRequestAsync(string postcode)
        {
            PostcodeResponse = await CallManager.MakePostcodeRequestAsync(postcode);
            Json_Response = JObject.Parse(PostcodeResponse);
            //Use DTO to convert JSON string to an object tree
            SinglePostcodeDTO.DeserialiseResponse(PostcodeResponse);
        }

        public int GetStatus()
        {
            return (int)CallManager.Response.StatusCode;
        }

        public int CodeCount()
        {
            return Json_Response["result"]["codes"].Count();
        }
    }
}
