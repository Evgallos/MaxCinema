using System.ComponentModel.DataAnnotations;

namespace MaxCinema.Models
{
    public class OrderRow
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
         
        public int MovieId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Order Order { get; set; }
    }
}
