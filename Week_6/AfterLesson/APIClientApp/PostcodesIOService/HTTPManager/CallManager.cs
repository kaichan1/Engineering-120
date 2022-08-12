using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientApp.PostcodesIOService.HTTPManager
{
    public class CallManager
    {
        #region properties
        private readonly RestClient _client;
        public RestResponse Response { get; set; }
        #endregion
        public CallManager()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
        }
        public async Task<string> MakePostcodeRequestAsync(string postcode)
        {
            //set up request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";
            //executing request
            Response = await _client.ExecuteAsync(request);
            return Response.Content;
        }
    }
}
