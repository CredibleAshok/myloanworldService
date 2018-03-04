﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLoanWorldService.Dto
{
    public class User
    {
        public int MyLoanWorldUserId { get; set; }
        public string UserName { get; set; }
        public string AccessKeyCode { get; set; }
        public int EnquiryId { get; set; }
        public DateTime CreationDate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string FeatureName { get; set; }
        public string EmailList { get; set; }
        public string AddressList { get; set; }

    }
}