using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientApp.PostcodesIOService.DataHandling
{
    public class DTO<ResponseType> where ResponseType : IResponse, new()
    {
        // The class is the model of the data returned by the API call.
        public ResponseType Response { get; set; }

        // Method that creates the above object using the response from the API
        public void DeserializeResponse(string postCodeResponse)
        {
            Response = JsonConvert.DeserializeObject<ResponseType>(postCodeResponse);
        }
    }
}
