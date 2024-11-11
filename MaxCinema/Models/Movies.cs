using System.ComponentModel.DataAnnotations;

namespace MaxCinema.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Director { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public string ReleaseYear { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }



    }
}
