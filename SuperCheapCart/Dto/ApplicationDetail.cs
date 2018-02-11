using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myloanworldService.Dto
{
    public class ApplicationDetail
    {
        public int ApplicationId { get; set; }
        public int ApplicationStatusId { get; set; }
        public string ApplicationStatus { get; set; }
        public int ApplicationTypeId { get; set; }        public string ApplicationType { get; set; }        public DateTime ValidTo { get; set; }        public DateTime ValidFrom { get; set; }        public DateTime CreationDate { get; set; }        public string CustomerName { get; set; }    }
}