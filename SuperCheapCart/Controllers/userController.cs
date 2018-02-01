using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SuperCheapCart.Controllers
{
    public class userController: ApiController
    {
        public string Name { get; set; }
        public string AccessKeyCode { get; set; }

        
    }
}