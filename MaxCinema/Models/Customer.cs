using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaxCinema.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string Firstname { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string Lastname { get; set; } = string.Empty;
        public string FullName { get { return $"{Firstname} {Lastname}"; } }
        [Required]
        [StringLength(200)]
        [DisplayName("Billing Address")]
        public string BillingAddress { get; set; } = string.Empty;
        [Required]
        [StringLength(10)]
        [DisplayName("Billing Zip")]
        public string BillingZip { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        [DisplayName("Billing City")]
        public string BillingCity { get; set; } = string.Empty;
        [Required]
        [StringLength(200)]
        [DisplayName("Delivery Address")]
        public string DeliveryAddress { get; set; } = string.Empty;
        [Required]
        [StringLength(10)]
        [DisplayName("Delivery Zip")]
        public string DeliveryZip { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        [DisplayName("Delivery City")]
        public string DeliveryCity { get; set; } = string.Empty;
        [Required]
        [StringLength(225)]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        [DisplayName("Phone Number")]
        public string Phone { get; set; } = string.Empty;

        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}
