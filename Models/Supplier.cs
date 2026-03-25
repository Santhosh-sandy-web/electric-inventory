using System.ComponentModel.DataAnnotations;

namespace ElectricInventorySystem.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Phone { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Address { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}