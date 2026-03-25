using System.ComponentModel.DataAnnotations;

namespace ElectricInventorySystem.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required string Role { get; set; }
    }
}