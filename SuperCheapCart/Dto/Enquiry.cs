﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myloanworldService.Dto
{
    public class Enquiry : BaseDto
    {
        public int EnquiryId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public double? LoanAmt { get; set; }
        public string Comments { get; set; }
        public int? Tennure { get; set; }
        public DateTime CreationDate { get; set; }
        public int? refferId { get; set; }
        public Customer customer { get; set; }
        public string EmailId { get; set; }
        public string UserId { get; set; }
        public string ContactUsEmail { get; set; }
    }
}