using System.ComponentModel.DataAnnotations;

namespace MaxCinema.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Firstname { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Lastname { get; set; } = string.Empty;
        public string FullName { get { return $"{Firstname} {Lastname}"; } }
        [Required]
        [StringLength(200)]
        public string BillingAddress { get; set; } = string.Empty;
        [Required]
        [StringLength(10)]
        public string BillingZip { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string BillingCity { get; set; } = string.Empty;
        [Required]
        [StringLength(200)]
        public string DeliveryAddress { get; set; } = string.Empty;
        [Required]
        [StringLength(10)]
        public string DeliveryZip { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string DeliveryCity { get; set; } = string.Empty;
        [Required]
        [StringLength(225)]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}
