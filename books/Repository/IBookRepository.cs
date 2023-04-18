using books.Models;

namespace books.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(long id);
        Task<Book> CreateAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task DeleteAsync(long id);
        Task<List<Book>> GetBooksByAuthorAsync(string author);
    }
}
