using CrudBlazorServerApp1.Data;
using CrudBlazorServerApp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CrudBlazorServerApp1.Repositorio
{
    public class Repositorio : IRepositorio
    {
        private readonly AplicationDBContext _dbContext;
        public Repositorio(AplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
/*En resumen, la línea de código "private readonly AplicationDBContext _dbContext;" es una variable de instancia de solo lectura que se utiliza para mantener una conexión segura y estable
 con una base de datos en una aplicación C#. La sintaxis de asignación utilizada en el constructor permite que la instancia de "AplicationDBContext" se proporcione externamente, 
lo que permite la inyección de dependencias y ayuda a lograr una mejor modularidad, escalabilidad y flexibilidad en la aplicación.*/
        public async Task<Book> ActualizarLibro(int BookId, Book UpdateBook)
        {
            var LibroDesdeDB = await _dbContext.Books.FindAsync(BookId);
            LibroDesdeDB.Title = UpdateBook.Title;
            LibroDesdeDB.Description = UpdateBook.Description;
            LibroDesdeDB.Autor = UpdateBook.Autor;
            LibroDesdeDB.Page = UpdateBook.Page;
            LibroDesdeDB.Datecreation = UpdateBook.Datecreation;
            LibroDesdeDB.Cost = UpdateBook.Cost;

            await _dbContext.SaveChangesAsync(); //Guarda los cambios 
            return LibroDesdeDB;
        }
        public async Task<Book> crearLibro(Book CreateBook)
        {
            if(CreateBook != null)
            {
                CreateBook.Datecreation = DateTime.Now;
                await _dbContext.Books.AddAsync(CreateBook); //Metodo que agrega un libro nuevo
                await _dbContext.SaveChangesAsync(); // metodo que guarda lo anterior a la base de datos 
                return CreateBook;
            }
            else
            {
                return new Book();
            }
        }

        public async Task DeleteBook(int BookId)
        {
            var LibroDesdeDB = await _dbContext.Books.FindAsync(BookId); //Metodo que busca el libro por el id
            _dbContext.Remove(LibroDesdeDB); // metodo que elimina el libro 
            await _dbContext.SaveChangesAsync(); // metodo que guarda lo anterior y ejecuta el borrado anterior en la base de datos
            
        }

        public async Task<Book> GetBookId(int BookId)
        {
            var LibroDesdeDB = await _dbContext.Books.FindAsync(BookId);
            if(LibroDesdeDB == null)
            {
                return new Book();
            }
            return LibroDesdeDB;
        }


        public Task<List<Book>> GetBooks()
        {
            return _dbContext.Books.ToListAsync();
        }

        
    }
}
