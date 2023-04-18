using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace books.Models
{
    public class Book
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Author { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Publisher { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public int NumPages { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}
