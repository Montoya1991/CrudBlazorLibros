using CrudBlazorServerApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudBlazorServerApp1.Data
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext>options)  : base(options)
        {

        }
        // colocar todos los modelos
        public DbSet<Book> Books { get; set; }
    }
}
