using CrudBlazorServerApp1.Models;
namespace CrudBlazorServerApp1.Repositorio
{
    public interface IRepositorio
    {
        public Task<List<Book>> GetBooks();
        public Task<Book> GetBookId(int BookId);
        public Task<Book> CreateBook(Book CreateBook);
        public Task<Book> UpdateBook(int BookId, Book UpdateBook);
        public Task DeleteBook(int BookId);


    }
}
