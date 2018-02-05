using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myloanworldService.Dto
{
    public class Customer : BaseDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string EnquiryId { get; set; }
        public string HomeAddress { get; set; }
        public string OfficeAddress { get; set; }
        public string HomeContact { get; set; }
        public string OfficeContact { get; set; }
        public string OtherContact { get; set; }
        public bool Sex { get; set; }
        public double LoanAmt { get; set; }
        public string AccessKeyCode { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        // todo, these properties need to be moved in different class
        public int ApplicationTypeId { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
    }
}