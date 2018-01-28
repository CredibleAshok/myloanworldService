using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace SuperCheapCart.Exception
{
    public static class CustomErrorConfigHandler
    {
        public static bool ShouldSupplyFullException
        {
            get
            {
                bool shouldShow = false;
                try
                {
                    CustomErrorsSection customErrors = new CustomErrorsSection(); //(CustomErrorsSection)WebConfigurationManager.OpenWebConfiguration("/");
                    CustomErrorsMode mode = customErrors.Mode;
                    if(mode== CustomErrorsMode.Off)
                    {
                        shouldShow = true;
                    }
                }
                catch 
                {
                    shouldShow = false;
                }
                return shouldShow;
            }
        }
    }
}