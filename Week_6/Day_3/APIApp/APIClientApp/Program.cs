using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace APIClientApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Encapsulate the information we need to make the api call
            //We can make authenticated HTTP requests
            var restClient = new RestClient("https://api.postcodes.io/");
            
            //Set up the request. Create a request object
            var restRequest = new RestRequest();
            restRequest.Method = Method.Get;
            restRequest.AddHeader("Content-Type", "application/json");
            var postCode = "EC2Y 5AS";
            restRequest.Resource = $"postcodes/{postCode.ToLower().Replace(" ", "")}";

            //Execute request
            RestResponse singlePostcodeResponse = await restClient.ExecuteAsync(restRequest);
            //Console.WriteLine("Response content (string)");
            //Console.WriteLine(singlePostcodeResponse.Content);
            //Console.WriteLine("Response code (enum)");
            //Console.WriteLine(singlePostcodeResponse.StatusCode);
            //Console.WriteLine("Response code (int)");
            //Console.WriteLine((int)singlePostcodeResponse.StatusCode);
            //Console.WriteLine("Headers");
            //foreach (var item in singlePostcodeResponse.Headers)
            //{
            //    Console.WriteLine(item);
            //}

            var responseContentType = singlePostcodeResponse.Headers.Where(x => x.Name == "Date")
                .Select(h => h.Value.ToString()).FirstOrDefault();

            //Console.WriteLine(responseContentType);

            var client = new RestClient();
            var request = new RestRequest("https://api.postcodes.io/postcodes/", Method.Post);
            request.AddHeader("Content-Type", "application/json");

            //request.AddStringBody("{​\r\n\"postcodes\" : [\"OX49 5NU\", \"M32 0JG\", \"NE30 1DP\"]\r\n}​\r\n", DataFormat.Json);

            var postcodes = new
            {
                Postcodes = new string[] { "PR3 0SG", "M45 6GN", "EX165BL" }
            };
            request.AddJsonBody(postcodes);
            RestResponse bulkPostcodeResponse = client.Execute(request);
            //Console.WriteLine(bulkPostcodeResponse.Content);

            //var singlePostcodeJsonResponse = JObject.Parse(singlePostcodeResponse.Content);
    
            //var adminDistrict = singlePostcodeJsonResponse["result"]["admin_district"];
            //Console.WriteLine(adminDistrict);


            //Repeat but with bulk post code response
            //Interrogate the JObject (like we've done above)
            var bulkPostcodeJsonResponse = JObject.Parse(bulkPostcodeResponse.Content);
            var query = bulkPostcodeJsonResponse["result"][0]["query"];
            Console.WriteLine(query);
            var query2 = bulkPostcodeJsonResponse["result"][1]["query"];
            Console.WriteLine(query2);
            var nuts = bulkPostcodeJsonResponse["result"][0]["result"]["nuts"];
            Console.WriteLine(nuts);
            var nuts2 = bulkPostcodeJsonResponse["result"][1]["result"]["nuts"];
            Console.WriteLine(nuts2);
            var codesNuts = bulkPostcodeJsonResponse["result"][0]["result"]["codes"]["nuts"];
            Console.WriteLine(codesNuts);
            var codesNuts2 = bulkPostcodeJsonResponse["result"][1]["result"]["codes"]["nuts"];
            Console.WriteLine(codesNuts2);

            //Admin county for the second object in the result array
            Console.WriteLine(bulkPostcodeJsonResponse["result"][1]["result"]["codes"]["admin_county"]);

            var list = bulkPostcodeJsonResponse["result"].ToList();

            var singlePostcodeObjectResponse = JsonConvert.DeserializeObject<SinglePostcodeResponse>(singlePostcodeResponse.Content);
            var bulkPostcodeObjectResponse = JsonConvert.DeserializeObject<BulkPostcodeResponse>(bulkPostcodeResponse.Content);

            Console.WriteLine("Bulk postcode response:\n");
            foreach (var p in bulkPostcodeObjectResponse.result)
            {
                Console.WriteLine(p.query);
                Console.WriteLine($"{p.result.admin_ward}\n");
            }

            var selectedAdminCounty = bulkPostcodeObjectResponse.result.Where(q => q.query == "PR3 0SG")
                .FirstOrDefault().result.codes.admin_county;
            
            var selectedAdminCountyAlt = bulkPostcodeObjectResponse.result[0].result.codes.admin_county;


            //Outcode
            var client2 = new RestClient("https://api.postcodes.io/");
            var request2 = new RestRequest();
            request2.AddHeader("Content-Type", "application/json");
            var outcode = "PR3";
            request2.Resource = $"outcodes/{outcode.ToLower()}";

            RestResponse outcodeResponse = await client2.ExecuteAsync(request2);
            var outcodeObjectResponse = JsonConvert.DeserializeObject<OutcodeResponse>(outcodeResponse.Content);
            Console.WriteLine("Outcode response:");
            Console.WriteLine(outcodeObjectResponse.result.country[0]);
            Console.WriteLine(outcodeObjectResponse.result.admin_district[0]);
        }
    }
}