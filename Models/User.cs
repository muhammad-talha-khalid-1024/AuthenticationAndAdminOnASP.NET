using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MyFirstDotNetApp.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; } = null!;
        
        [Required]
        [MaxLength(255)]
        public string Password { get; set; } = null!;
    }
}