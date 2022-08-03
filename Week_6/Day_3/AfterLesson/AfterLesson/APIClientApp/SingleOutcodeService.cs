using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APIClientApp
{
    public class SingleOutcodeService
    {
        #region Properties
        //RestSharp object whic handles comms with the API
        public RestClient Client { get; set; }
        // Captures the response
        public RestResponse Response { get; set; }

        //Capture the response body JSON
        public JObject ResponseContent { get; set; }

        public SingleOutcodeResponse ResponseObject { get; set; }
        #endregion
        public SingleOutcodeService()
        {
            Client = new RestClient(AppConfigReader.BaseUrl);
        }

        //Method that defines and makes the API request and storse the response
        public async Task MakesRequestAsync(string outcode)
        {
            //set up the request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"outcodes/{outcode.ToLower().Replace(" ", "")}";

            //Make request
            Response = await Client.ExecuteAsync(request);

            //Parse JSON body to ResponseContent
            ResponseContent = JObject.Parse(Response.Content);

            //an object model of the response
            ResponseObject = JsonConvert.DeserializeObject<SingleOutcodeResponse>(Response.Content);
        }

        public int GetStatusCode()
        {
            return (int)Response.StatusCode;
        }
    }
}
