using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string? Status { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User? User { get; set; }

        // Коллекция элементов заказа
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    };
}
