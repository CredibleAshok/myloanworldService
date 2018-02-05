using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myloanworldService.Dto
{
    public class ApplicationHistory
    {
        public int ApplicationHistoryId { get; set; }
        public int ApplicationId { get; set; }
        public int ApplicationStatusId { get; set; }
        public string Comments { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ApplicationStatus { get; set; }
    }
}