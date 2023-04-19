using CrudBlazorServerApp1.Models;
namespace CrudBlazorServerApp1.Repositorio
{
    public interface IRepositorio
    {
        public Task<List<Book>> GetBooks();
        public Task<Book> GetBookId(int libroId);
        public Task<Book> crearLibro(Book createBook);
        public Task<Book> ActualizarLibro(int libroId, Book actualizarLibro);
        public Task DeleteBook(int libroId);


    }
}
