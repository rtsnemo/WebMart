using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string? Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int? QuantityInStock { get; set; }

        public virtual ICollection<OrderItem>? OrderItems { get; set; }

        public virtual ICollection<Review>? Reviews { get; set; }
    };
}
