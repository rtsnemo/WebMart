﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        public string? Comment { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public User? User { get; set; }

        public int ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Product? Product { get; set; }
    };
}
