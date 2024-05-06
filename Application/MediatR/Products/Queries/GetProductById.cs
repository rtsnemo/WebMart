using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Products.Queries
{
    public class GetProductById : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
