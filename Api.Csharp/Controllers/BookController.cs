using System;
using System.Net;
using System.Threading.Tasks;
using Api.Csharp.Model;
using Api.Csharp.Service;
using Api.Csharp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IApiService _apiService;
        public BookController(IApiService service)
        {
            _apiService = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async Task<IActionResult> AddBooks(Book book)
        {
            var request = await _apiService.PostBooks(book);

            if(request.StatusCode != HttpStatusCode.Created)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var request = await _apiService.GetAllBooks();

            if(request.StatusCode != HttpStatusCode.OK)
            {
                return BadRequest();
            }
            return Ok(request.Content);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody]Book book, [FromRoute]string id)
        {
            var request = await _apiService.UpdateBook(book, id);

            if(request.StatusCode != HttpStatusCode.NoContent)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            var request = await _apiService.DeleteBook(id);

            if(request.StatusCode != HttpStatusCode.OK)
            {
                return BadRequest();
            }

            return Ok();
        }


    }
}