using book_blog_api.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace book_blog_api.DTOs;

public class BookService
{
    private readonly BlogContext _context;

    public BookService(BlogContext context)
    {
        _context = context;
    }

    private BookDTO BookToDTO(Book book)
    {
        return new BookDTO
        {
            id = book.id,
            title = book.title,
            author = book.author,
            genre = book.genre,
            publicationDate = book.publicationDate,
            ISBN = book.ISBN,
            coverImage = book.coverImage,
            description = book.description,
            review = book.review,
            rating = book.rating,
            readDate = book.readDate,
            tags = book.tags.Select(tag => tag.name).ToList()
        };
    }

    private async Task<Book> DTOToBook(BookDTO dto)
    {
        Book book = new Book()
        {
            id = dto.id,
            title = dto.title,
            author = dto.author,
            genre = dto.genre,
            publicationDate = dto.publicationDate,
            ISBN = dto.ISBN,
            coverImage = dto.coverImage,
            description = dto.description,
            review = dto.review,
            rating = dto.rating,
            readDate = dto.readDate,
            tags = await GetOrCreateTags(dto.tags)
        };

        return book;
    }

    private async Task<List<Tag>> GetOrCreateTags(List<string> tags)
    {
        List<Tag> newTags = new List<Tag>();

        foreach (var tagName in tags)
        {
            var existingTag = await _context.Tags.FirstOrDefaultAsync(tag => tag.name == tagName);

            // If the tag doesn't exist, create a new one
            if (existingTag == null)
            {
                existingTag = new Tag { name = tagName };
                _context.Tags.Add(existingTag);
            }

            // Add the BookTag to the Book
            newTags.Add(existingTag);
        }

        // Save changes to the database if needed
        await _context.SaveChangesAsync();

        return newTags;
    }

    public bool BookExists(int id)
    {
        return _context.Books.Any(e => e.id == id);
    }

    public async Task<List<BookDTO>> GetBookDTOListAsync()
    {
        List<Book> books = await _context.Books.Include(book => book.tags).ToListAsync();

        List<BookDTO> bookDtos = books.Select(BookToDTO).ToList();

        return bookDtos;
    }

    public async Task<BookDTO?> GetBookDTOAsync(int id)
    {
        Book? book = await _context.Books.Include(b => b.tags).FirstOrDefaultAsync(b => b.id == id);

        if (book == null)
        {
            return null;
        }

        return BookToDTO(book);
    }

    public async Task<IActionResult> UpdateBook(BookDTO bookDTO)
    {
        Book book = await DTOToBook(bookDTO);
        _context.Entry(book).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return new NoContentResult();
    }

    public async Task<BookDTO> AddBook(BookDTO bookDTO)
    {
        Book book = await DTOToBook(bookDTO);
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return bookDTO;
    }

    public async Task<bool> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return false;
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return true;
    }

}