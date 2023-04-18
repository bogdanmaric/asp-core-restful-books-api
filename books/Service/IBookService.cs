using books.Models;

namespace books.Service
{
    public interface IBookService
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);

        Task<Book> CreateAsync(Book book);

        Task<Book> UpdateAsync(Book book);

        Task DeleteAsync(int id);

        //Additional methods
        Task<List<Book>> GetBooksByAuthorAsync(string author);

    }
}
