using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APIClientApp
{
    public class BulkPostcodeService
    {
        #region Properties
        //RestSharp object whic handles comms with the API
        public RestClient Client { get; set; }
        // Captures the response
        public RestResponse Response { get; set; }

        //Capture the response body JSON
        public JObject ResponseContent { get; set; }

        public BulkPostcodeResponse ResponseObject { get; set; }
        #endregion
        public BulkPostcodeService()
        {
            Client = new RestClient();
        }

        //Method that defines and makes the API request and storse the response
        public async Task MakesRequestAsync(object postcodes)
        {
            //set up the request
            var request = new RestRequest($"{AppConfigReader.BaseUrl}/postcodes/", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(postcodes);

            //Make request
            Response = await Client.ExecuteAsync(request);

            //Parse JSON body to ResponseContent
            ResponseContent = JObject.Parse(Response.Content);

            //an object model of the response
            ResponseObject = JsonConvert.DeserializeObject<BulkPostcodeResponse>(Response.Content);
        }

        public int GetStatusCode()
        {
            return (int)Response.StatusCode;
        }
    }
}
