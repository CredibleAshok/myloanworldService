using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myloanworldService.Dto
{
    public class Menus
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public int? SortOrder { get; set; }        public int ParentMenu { get; set; }
        public string Href { get; set; }
        public string Icon { get; set; }
        public string Sref { get; set; }
        public string Localhref { get; set; }
        public bool IsManagement { get; set; }        public DateTime ValidTo { get; set; }        public DateTime ValidFrom { get; set; }        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}