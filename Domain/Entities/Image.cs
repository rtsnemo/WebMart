using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }

        [Required]
        public string Base64Data { get; set; }
    }
}
