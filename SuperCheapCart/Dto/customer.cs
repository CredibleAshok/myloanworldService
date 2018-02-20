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
        public int EnquiryId { get; set; }
        public string HomeAddress { get; set; }
        public string OfficeAddress { get; set; }
        public string HomeContact { get; set; }
        public string OfficeContact { get; set; }
        public string OtherContact { get; set; }
        public int? SexId { get; set; }
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

        /////////////////
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? MaritalStatusId { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string OtherPersonal { get; set; }
        public string HusbandName { get; set; }
        public string LocalHomeContact { get; set; }
        public string LocalOfficeContact { get; set; }
        public string LocalOfficeAddress { get; set; }
        public string LocalHomeAddress { get; set; }

    }
}