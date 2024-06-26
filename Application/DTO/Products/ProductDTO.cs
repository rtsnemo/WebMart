﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Products
{
    public class ProductDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }
    }
}
