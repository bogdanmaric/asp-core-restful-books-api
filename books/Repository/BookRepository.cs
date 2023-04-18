using books.Data;
using books.Models;
using Microsoft.EntityFrameworkCore;

namespace books.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Book?> GetByIdAsync(long id)
        {
            return await _applicationDbContext.Books_core.FindAsync(id);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _applicationDbContext.Books_core.ToListAsync();
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await _applicationDbContext.Books_core.AddAsync(book);
            await _applicationDbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            _applicationDbContext.Books_core.Update(book);
            await _applicationDbContext.SaveChangesAsync();
            return book;
        }

        public async Task DeleteAsync(long id)
        {
            var book = await GetByIdAsync(id);
            if (book != null)
            {
                _applicationDbContext.Books_core.Remove(book);
                await _applicationDbContext.SaveChangesAsync();

            }
        }

        public async Task<List<Book>> GetBooksByAuthorAsync(string author)
        {
            return await _applicationDbContext.Books_core.Where(b => b.Author == author).ToListAsync();
        }
    }
}
