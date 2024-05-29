using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Users.Commands
{
    public class UpdateUser : IRequest<User>
    {
        public int UserId {  get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
