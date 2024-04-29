using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Users.Queries
{
    public class SignInUser : IRequest<string>
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
