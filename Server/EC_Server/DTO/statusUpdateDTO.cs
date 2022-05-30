﻿using EC_Server.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC_Server.DTO
{
    public class statusUpdateDTO
    {
        public int UserId { get; set; }
        public Guid BasketId { get; set; }
        public BasketStatus Status { get; set; }
    }
}
