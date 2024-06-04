using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Products.Commands
{
    public class UpdateProduct : IRequest<Product>
    {
            public int ProductID { get; set; }

            public string UrlImage { get; set; }
            public string Name { get; set; }

            public decimal Price { get; set; }
            public int? QuantityInStock { get; set; }

        };
}
