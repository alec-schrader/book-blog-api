using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using book_blog_api.Models;
using book_blog_api.DTOs;

namespace book_blog_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            List<BookDTO> BookDTOs = await _bookService.GetBookDTOListAsync();

            return BookDTOs;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            BookDTO? book = await _bookService.GetBookDTOAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookDTO book)
        {
            if (id != book.id)
            {
                return BadRequest();
            }

            try
            {
                await _bookService.UpdateBook(book);
            }
            catch (Exception)
            {
                if (!_bookService.BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookDTO book)
        {
            BookDTO bookDTO = await _bookService.AddBook(book);
            
            return CreatedAtAction("GetBook", new { id = bookDTO.id }, bookDTO);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            bool deleted = await _bookService.DeleteBook(id);

            if (!deleted) return BadRequest();

            return NoContent();
        }

    }
}
