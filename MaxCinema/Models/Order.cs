using System.ComponentModel.DataAnnotations;

namespace MaxCinema.Models
{
    public class Order
    {
        [Key] 
        public int OId { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        public string Director { get; set; } = string.Empty;

        public int OrderId { get; set; }

    }
}
