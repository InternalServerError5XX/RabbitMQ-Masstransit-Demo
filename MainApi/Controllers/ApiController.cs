using BookApi;
using Contracts.Models;
using MainApi.Services.BookConsumerService;
using MainApi.Services.BooksConsumerService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace MainApi.Controllers
{
    [Route("api")]
    [ApiController]
    [TypeFilter(typeof(ApiExceptionFilter))]
    public class ApiController(IBookConsumerService bookConsumerService, IBooksConsumerService booksConsumerService, 
        IHttpClientFactory httpClientFactory) : ControllerBase
    {
        private readonly HttpClient httpClient = httpClientFactory.CreateClient("books-api");

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            await httpClient.GetAsync("");
            var response = booksConsumerService.GetMessage();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            await httpClient.GetAsync($"{id}");
            var response = bookConsumerService.GetMessage();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDto bookDto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(bookDto), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("", content);
            var response = bookConsumerService.GetMessage();

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookDto bookDto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(bookDto), Encoding.UTF8, "application/json");
            await httpClient.PatchAsync($"{id}", content);
            var response = bookConsumerService.GetMessage();

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await httpClient.DeleteAsync($"{id}");
            var response = bookConsumerService.GetMessage();

            return Ok(response);
        }
    }
}
