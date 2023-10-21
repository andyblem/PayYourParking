﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.DTOs
{
    public class CreatePaymentDTO
    {
        public decimal? Amount { get; set; }

        public string Email { get; set; }
        public string MobileMoney { get; set; }
        public string PhoneNumber { get; set; }
    }
}
