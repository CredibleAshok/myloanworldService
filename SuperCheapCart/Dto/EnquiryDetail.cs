using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myloanworldService.Dto
{
    public class EnquiryDetailDto : BaseDto
    {
        public int IdenquiryDetailId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public int LoanAmt { get; set; }
        public string Comments { get; set; }
    }
}