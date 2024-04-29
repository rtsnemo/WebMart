using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Users
{
    public interface IPasswordHasher
    {
        public bool VerifyPassword(string enteredPassword, string storedHash, string salt);

        public (string Hash, string Salt) HashPassword(string password);
    }
}
