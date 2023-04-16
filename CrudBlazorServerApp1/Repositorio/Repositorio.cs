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
        public async Task<Book> CreateBook(Book CreateBook)
        {
            if(CreateBook != null)
            {
                CreateBook.Datecreation = DateTime.Now;
                await _dbContext.Books.AddAsync(CreateBook);
                await _dbContext.SaveChangesAsync();
                return CreateBook;
            }
            else
            {
                return new Book();
            }
        }

        public async Task DeleteBook(int BookId)
        {
            var LibroDesdeDB = await _dbContext.Books.FindAsync(BookId);
            _dbContext.Remove(LibroDesdeDB);
            await _dbContext.SaveChangesAsync();
            
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

        public async Task<Book> UpdateBook(int BookId, Book UpdateBook)
        {
            var LibroDesdeDB = await _dbContext.Books.FindAsync(BookId);
            LibroDesdeDB.Title = UpdateBook.Title;
            LibroDesdeDB.Description = UpdateBook.Description;
            LibroDesdeDB.Autor=UpdateBook.Autor;
            LibroDesdeDB.Page = UpdateBook.Page;
            LibroDesdeDB.Datecreation = UpdateBook.Datecreation;
            LibroDesdeDB.Cost = UpdateBook.Cost;

            await _dbContext.SaveChangesAsync();
            return LibroDesdeDB;
        }
    }
}
