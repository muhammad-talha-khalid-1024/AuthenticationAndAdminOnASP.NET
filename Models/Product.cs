using System.ComponentModel.DataAnnotations;

namespace MyFirstDotNetApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = null!;
        
        [Required]
        public string Description { get; set; } = null!;
        
        [Required]
        public float Price { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Color { get; set; } = null!;
        
        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = null!;
    }
}