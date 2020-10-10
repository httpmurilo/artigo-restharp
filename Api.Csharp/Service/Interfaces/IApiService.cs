using System.Threading.Tasks;
using Api.Csharp.Model;
using RestSharp;

namespace Api.Csharp.Service.Interfaces
{
    public interface IApiService
    {
        Task<IRestResponse> PostBooks(Book book);
        Task<IRestResponse> GetAllBooks();
        Task<IRestResponse> UpdateBook(Book book, string id);
        Task<IRestResponse> DeleteBook(string id);
    }
}