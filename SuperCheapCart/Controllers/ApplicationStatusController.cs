using myloanworldService.common;
using myloanworldService.Dto;
using MySql.Data.MySqlClient;
using SuperCheapCart.common;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SuperCheapCart.Controllers
{
    public class ApplicationStatusController : ApiController
    {
        ConnectionMaker connection = new ConnectionMaker();
        EmailSender emailsender = new EmailSender("letusknow@myloanworld.com", "ashok.forklift@gmail.com", "Email body Ashok", "Email Subject Ashok");

        [Route("api/getApplicationStatus")]
        [HttpGet]
        public IList<ApplicationStatus> getApplicationStatus()
        {
            //throw new ArgumentNullException();
            List<ApplicationStatus> applicationStatusList = new List<ApplicationStatus>();
            string query = "SELECT * FROM myloanworld.applicationStatus";
            //string emailStatus = emailsender.SendEmailViaWebApi();

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
                                //Name = emailStatus //reader["name"].ToString()
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