using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        
        public string? UrlImage { get; set; }

        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

        public string? Salt { get; set; }

        [Required]
        public UserRole Role { get; set; } // Использование enum для роли

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Balance { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    };
}
