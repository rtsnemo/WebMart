using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Reviews.Commands
{
    public class CreateReview : IRequest<int>
    {
        public string Comment { get; set; }
        public int UserId {  get; set; }
        public int ProductId { get; set; }
    }
}
