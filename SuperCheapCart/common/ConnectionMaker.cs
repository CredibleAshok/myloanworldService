using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace myloanworldService.common
{
    public class ConnectionMaker
    {
        public string MySQLConnectionString;
        public ConnectionMaker()
        {
            string environment = ConfigurationManager.AppSettings["Environment"];
            if (environment == "local")
            {
                MySQLConnectionString = ConfigurationManager.AppSettings["LocalMYSqlConnectionString"];
            }
            else if (environment == "localIIS")
            {
                MySQLConnectionString = ConfigurationManager.AppSettings["LocalIISMYSqlConnectionString"];
            }
            else if (environment == "live")
            {
                MySQLConnectionString = ConfigurationManager.AppSettings["LiveMYSqlConnectionString"];
            }
        }
    }
}