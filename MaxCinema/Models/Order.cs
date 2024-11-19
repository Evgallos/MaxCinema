using System.ComponentModel.DataAnnotations;

namespace MaxCinema.Models
{
    public class Order
    {
      
        [Key] 
        public int Id { get; set; }


        [Required]
        public DateTime OrderDate {  get; set; }
        
        public Customer Customer { get; set; }

        public List<OrderRow> ListOrderRow { get; set; } = new List<OrderRow>();

        //public virtual ICollection<OrderRow> ListOrderRows { get; set; }

    }
}
