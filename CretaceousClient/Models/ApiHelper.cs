using System.Threading.Tasks;
using RestSharp;

namespace CretaceousClient.Models
{
    class ApiHelper
    {
        public static async Task<string> GetAll()
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"animals", Method.GET);
            IRestResponse response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> Get(int id)
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"animals/{id}", Method.GET);
            IRestResponse response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task Post(string newAnimal)
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"animals", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newAnimal);
            IRestResponse response = await client.ExecuteTaskAsync(request);
        }

        public static async Task Put(int id, string newAnimal)
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"animals/{id}", Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newAnimal);
            IRestResponse response = await client.ExecuteTaskAsync(request);
        }

        public static async Task Delete(int id)
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"animals/{id}", Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = await client.ExecuteTaskAsync(request);
        }
    }
}