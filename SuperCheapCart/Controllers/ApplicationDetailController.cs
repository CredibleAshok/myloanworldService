﻿using myloanworldService.Dto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SuperCheapCart.Controllers
{
    public class ApplicationDetailController : ApiController
    {
        public string MyConnectionString = ConfigurationManager.AppSettings["Environment"] == "local" ? ConfigurationManager.AppSettings["LocalMYSqlConnectionString"] : ConfigurationManager.AppSettings["MYSqlConnectionString"];
        [Route("api/getApplicationById")]
        [HttpGet]
        public IList<ApplicationDetail> getApplication([FromBody] int? applicationId)
        {
            List<ApplicationDetail> applicationDetailList = new List<ApplicationDetail>();
            string query = "";
            if (applicationId != null)
            {
                query = @"SELECT apd.applicationId, apd.applicationStatusId, aps.name as 'applicationStatus', apd.applicationTypeId, apt.name as 'applicationType'
                            FROM myloanworld.applicationdetail apd
                            join myloanworld.applicationstatus aps on aps.applicationStatusId = apd.applicationStatusId
                            join myloanworld.applicationtype apt on apt.applicationTypeId = apd.applicationTypeId where applicationId='" + applicationId + "'"; 
            }
            else
            {
                query = @"SELECT apd.applicationId, apd.applicationStatusId, aps.name as 'applicationStatus', apd.applicationTypeId, apt.name as 'applicationType'
                            FROM myloanworld.applicationdetail apd
                            join myloanworld.applicationstatus aps on aps.applicationStatusId = apd.applicationStatusId
                            join myloanworld.applicationtype apt on apt.applicationTypeId = apd.applicationTypeId";
            }
            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(MyConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                applicationDetailList.Add(new ApplicationDetail()
                                {
                                    ApplicationId = Convert.ToInt16(reader["applicationId"]),
                                    ApplicationStatusId = Convert.ToInt16(reader["applicationStatusId"]),
                                    ApplicationStatus = reader["applicationStatus"].ToString(),
                                    ApplicationTypeId = Convert.ToInt16(reader["applicationTypeId"]),
                                    ApplicationType = reader["applicationType"].ToString(),
                                });
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
            }
            return applicationDetailList;
        }
    }
}