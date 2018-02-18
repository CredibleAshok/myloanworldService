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

        [Route("api/updateApplicationStatus")]
        [HttpPost]
        public string UpdateApplicationStatus([FromBody] ApplicationStatus applicationStatus)
        {
            string result = "";
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                string spName = "update_applicationStatus";
                using (MySqlCommand cmd = new MySqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@_Name", applicationStatus.Name);
                    cmd.Parameters.AddWithValue("@_ApplicationStatusId", applicationStatus.ApplicationStatusId);
                    cmd.Parameters.AddWithValue("@_UpdatedBy", applicationStatus.UpdatedBy);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                result = "Success";
            }
            return result;
        }

        [Route("api/saveApplicationStatus")]
        [HttpPost]
        public string SaveApplicationStatus([FromBody] ApplicationStatus applicationStatus)
        {
            string result = "";
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                string spName = "save_applicationStatus";
                using (MySqlCommand cmd = new MySqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@_Name", applicationStatus.Name);
                    cmd.Parameters.AddWithValue("@_UpdatedBy", applicationStatus.UpdatedBy);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                result = "Success";
            }
            return result;
        }
    }
}