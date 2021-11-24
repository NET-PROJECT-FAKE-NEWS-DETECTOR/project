﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AdminAuth : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

    }
}
