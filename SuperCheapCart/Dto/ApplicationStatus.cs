using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myloanworldService.Dto
{
    public class ApplicationStatus
    {
        public int ApplicationStatusId { get; set; }
        public string Name { get; set; }        public DateTime ValidTo { get; set; }        public DateTime ValidFrom { get; set; }
    }
}