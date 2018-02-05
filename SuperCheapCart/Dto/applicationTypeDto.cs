using myloanworldService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myloanworldService.Dto
{
    public class ApplicationTypeDto : BaseDto
    {
        public int applicationTypeId { get; set; }
        public string name { get; set; }
        public string descText { get; set; }
        public string href { get; set; }
        public string icon { get; set; }
        public string sref { get; set; }
        public string localhref { get; set; }
        //public DateTime? validFrom { get; set; }
        //public DateTime? validTo { get; set; }
        //public DateTime? updatedDate { get; set; }
        public string updatedBy { get; set; }
    }
}