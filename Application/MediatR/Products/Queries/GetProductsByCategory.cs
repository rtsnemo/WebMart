using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Products.Queries
{
    public class GetProductsByCategory(int categoryID) : IRequest<ICollection<Product>>
    {
        public int categoryID { get; set; }
    }
}
