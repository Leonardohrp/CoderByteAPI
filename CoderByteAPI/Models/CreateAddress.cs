using CoderByteAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Models
{
    public class CreateAddress
    {
        [Required]
        public string ZipCode { get; set; }

        [Required]
        public CategoryEnum Categoria { get; set; }
    }
}
