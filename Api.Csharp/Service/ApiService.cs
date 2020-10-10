using System;
using System.Threading.Tasks;
using Api.Csharp.Model;
using Api.Csharp.Service.Interfaces;
using RestSharp;

namespace Api.Csharp.Service
{
    public class ApiService : IApiService
    {
        private const string BaseUrl = "http://localhost:3011/";

        public async Task<IRestResponse> PostBooks(Book book)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(book);
            IRestResponse response = await client.ExecuteAsync(request);
            
            return response;
        }

        public async Task<IRestResponse> GetAllBooks()
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);

            return response;
        }

        public async Task<IRestResponse> UpdateBook(Book book, string id)
        {
            var client = new RestClient(BaseUrl + id);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(book);
            IRestResponse response = await client.ExecuteAsync(request);
            
            return response;
        }
        public async Task<IRestResponse> DeleteBook(string id)
        {
            var client = new RestClient(BaseUrl + id);
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = await client.ExecuteAsync(request);

            return response;
        }
    }
}