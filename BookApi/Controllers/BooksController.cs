using Microsoft.AspNetCore.Mvc;
using BookApi.Models;
using MassTransit;
using MassTransit.Transports;
using System.Transactions;
using BookApi.Messages;
using BookApi.Services.BooksService;

namespace BookApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [TypeFilter(typeof(ApiExceptionFilter))]
    public class BooksController(IBookService bookService, IPublishEndpoint publishEndpoint) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BooksMessage>> GetBooks()
        {
            var books = bookService.GetBooks();
            var response = new BooksMessage { Books = books };
            await publishEndpoint.Publish(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookMessage>> GetBook(int id)
        {
            var response = bookService.GetBook(id);
            await publishEndpoint.Publish(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(BookDto bookDto)
        {
            var response = bookService.AddBook(bookDto);
            await publishEndpoint.Publish(response);

            return CreatedAtAction(nameof(GetBook), new { id = response.Id }, response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookDto bookDto)
        {
            var response = bookService.UpdateBook(id, bookDto);;
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
