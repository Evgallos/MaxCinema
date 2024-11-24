using System.ComponentModel.DataAnnotations;

namespace MaxCinema.Models
{
    public class Movie
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
        public int ReleaseYear { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [StringLength(300)]
        public string Url { get; set; } = string.Empty;

        public string TitleAndYear {
            get {  
                return $"{Title} ({ReleaseYear})"; }
                }

        public virtual ICollection<OrderRow>? OrderRows { get; set; }

    }
}
