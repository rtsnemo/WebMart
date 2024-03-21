﻿using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Users.Commands
{
    public class CreateUser : IRequest<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
