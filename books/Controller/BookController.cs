using books.Models;
using books.Service;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;

namespace books.Controller
{
    [ApiController]
    [Route("api/v1/books")]
    //[Route("api/v1/[controller]s")]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("author/{author}")]
        public async Task<ActionResult<List<Book>>> GetBooksByAuthor(string author)
        {
            var books = await _bookService.GetBooksByAuthorAsync(author);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            var createdBook = await _bookService.CreateAsync(book);
            return CreatedAtAction(nameof(GetById), new {id = createdBook.Id}, createdBook);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Update(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var updatedBook = await _bookService.UpdateAsync(book);

            if (updatedBook == null)
            {
                return NotFound();
            }

            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }


    }
}
