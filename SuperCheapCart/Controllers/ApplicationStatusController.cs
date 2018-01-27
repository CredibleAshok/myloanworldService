using myloanworldService.common;
using myloanworldService.Dto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SuperCheapCart.Controllers
{
    public class ApplicationStatusController : ApiController
    {
        ConnectionMaker connection = new ConnectionMaker();
        [Route("api/getApplicationStatus")]
        [HttpGet]
        public IList<ApplicationStatus> getApplicationStatus()
        {
            throw new ArgumentNullException();
            List<ApplicationStatus> applicationStatusList = new List<ApplicationStatus>();
            string query = "SELECT * FROM myloanworld.applicationStatus";
            

            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                applicationStatusList.Add(new ApplicationStatus()
                                {
                                    ApplicationStatusId = Convert.ToInt16(reader["applicationStatusId"]),
                                    Name = reader["name"].ToString()
                                });
                            }
                        }
                    }
                    conn.Close();
                }
            return applicationStatusList;
        }
    }
}