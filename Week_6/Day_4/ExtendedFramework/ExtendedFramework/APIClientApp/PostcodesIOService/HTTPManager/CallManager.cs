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
        //Restsharp object which handles communication with the API
        private readonly RestClient _client;
        private RestRequest _request;
        public RestResponse Response { get; set; }

        public CallManager()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
            _request = new RestRequest();
            _request.AddHeader("Content-Type", "application/json");
        }

        /// <summary>
        /// defines and makes the API request, and stores the response
        /// </summary>
        /// <param name="postcode"></param>
        public async Task<string> MakeRequestAsync(Resource resource, string code, Method method)
        {
            if (method == Method.Post)
            {
                _request.Resource = $"{resource}/";
                _request.AddJsonBody(new { Postcodes = code.Split(',') });
                _request.Method = method;
                Response = await _client.ExecuteAsync(_request);
                return Response.Content;
            }
            else 
            {
                _request.Resource = $"{resource}/{code.ToLower().Replace(" ", "")}";
                _request.Method = method;
                Response = await _client.ExecuteAsync(_request);
                return Response.Content;
            }

        }


    }
}
