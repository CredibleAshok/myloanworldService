using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperCheapCart.Dto
{
    public class User
    {
        public int MyLoanWorldUserId { get; set; }
        public string UserName { get; set; }
        public string AccessKeyCode { get; set; }
        public int EnquiryId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}