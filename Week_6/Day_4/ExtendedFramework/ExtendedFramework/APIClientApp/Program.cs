using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using APIClientApp.PostcodesIOService.DataHandling;

namespace APIClientApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Encapsulate the information we need to make the api call
            //We can make authneticated HTTP requests
            var restClient = new RestClient("https://api.postcodes.io/");
            
            //Set up the request. Create a request object
            var restRequest = new RestRequest();
            restRequest.Method = Method.Get;
            restRequest.AddHeader("Content-Type", "application/json");
            var postcode = "EC2Y 5AS";
            restRequest.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

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

            // request.AddStringBody("{\r\n\"postcodes\" : [\"OX49 5NU\", \"M32 0JG\", \"NE30 1DP\"]\r\n}\r\n", DataFormat.Json);

            var postcodes = new
            {
                Postcodes = new string[] { "PR3 0SG", "M45 6GN", "EX165BL" }
            };
            request.AddJsonBody(postcodes);
            RestResponse bulkPostcodeResponse = client.Execute(request);
            //Console.WriteLine(bulkPostcodeResponse.Content);

            var singlePostcodeJsonResponse = JObject.Parse(singlePostcodeResponse.Content);


            var bulkPostcodesJsonResponse = JObject.Parse(bulkPostcodeResponse.Content);
            //Console.WriteLine("\nBulk postcode response content as a JObject");
            //Console.WriteLine(bulkPostcodesJsonResponse);

            //Console.WriteLine(bulkPostcodesJsonResponse["result"][0]["query"]);

            //Admin county for the second object in the result array
            Console.WriteLine(bulkPostcodesJsonResponse["result"][1]["result"]["codes"]["admin_county"]);

            var list = bulkPostcodesJsonResponse["result"].ToList();

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

        }
    }
}