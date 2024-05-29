using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Users
{
    public class UpdateUserDTO
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string ImageUrl { get; set; }
    }
}
