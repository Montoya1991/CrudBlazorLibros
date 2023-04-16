using System.ComponentModel.DataAnnotations;

namespace CrudBlazorServerApp1.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public int Page { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public DateTime Datecreation { get; set; }
    }
}
