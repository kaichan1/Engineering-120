using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientApp
{
    public class SinglePostcodeService
    {
        #region Properties
        //RestSharp object whic handles comms with the API
        public RestClient Client { get; set; }
        // Captures the response
        public RestResponse Response { get; set; }
        //Capture the response body JSON
        public JObject ResponseContent { get; set; }
        public SinglePostcodeService()
        {
            Client = new RestClient(AppConfigReader.BaseUrk);
        }
        #endregion
    }
}
}
