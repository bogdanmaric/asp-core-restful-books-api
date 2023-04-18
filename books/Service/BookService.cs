using books.Data;
using books.Models;
using books.Repository;

namespace books.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> CreateAsync(Book book)
        {
            return await _bookRepository.CreateAsync(book);
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            return await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<List<Book>> GetBooksByAuthorAsync(string author)
        {
            return await _bookRepository.GetBooksByAuthorAsync(author);
        }
    }
}
