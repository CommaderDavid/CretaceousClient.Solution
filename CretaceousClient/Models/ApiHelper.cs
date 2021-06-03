using RestSharp;
using System.Threading.Tasks;

namespace CretaceousClient.Models
{
    class ApiHelper
    {
        public static async Task<string> GetAll()
        {
            RestClient client = new RestClient("http://localhost:5004/api");
            RestRequest request = new RestRequest($"animals", Method.GET);
            IRestResponse response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
    }
}