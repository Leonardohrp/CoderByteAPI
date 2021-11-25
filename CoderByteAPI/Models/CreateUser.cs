using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Models
{
    public class CreateUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public List<CreateAddress> AddressInformations { get; set; }
    }
}
