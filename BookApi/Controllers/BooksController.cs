using Microsoft.AspNetCore.Mvc;
using MassTransit;
using BookApi.Messages;
using BookApi.Services.BooksService;
using Contracts.Models;

namespace BookApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    [TypeFilter(typeof(ApiExceptionFilter))]
    public class BooksController(IBookService bookService, IPublishEndpoint publishEndpoint) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = bookService.GetBooks();
            var response = new BooksMessage { Books = books };
            await publishEndpoint.Publish(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var response = bookService.GetBook(id);
            await publishEndpoint.Publish(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDto bookDto)
        {
            var response = bookService.AddBook(bookDto);
            await publishEndpoint.Publish(response);

            return CreatedAtAction(nameof(GetBook), new { id = response.Id }, response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookDto bookDto)
        {
            var response = bookService.UpdateBook(id, bookDto);
            await publishEndpoint.Publish(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = bookService.DeleteBook(id);
            await publishEndpoint.Publish(response);

            return Ok(response);
        }
    }
}
