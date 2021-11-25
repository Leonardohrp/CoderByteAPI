﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Dtos
{
    public class UserUpdatedDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string? Phone { get; set; }
    }
}
