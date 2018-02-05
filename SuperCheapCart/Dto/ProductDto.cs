using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myloanworldService.Dto
{
    public class ProductDto: BaseDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}