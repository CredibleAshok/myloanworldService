﻿using myloanworldService.common;
using myloanworldService.Dto;
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
        ConnectionMaker connection = new ConnectionMaker();
        [Route("api/getApplicationById")]
        [HttpGet]
        public IList<ApplicationDetail> getApplication([FromBody] int? applicationId)
        {
            List<ApplicationDetail> applicationDetailList = new List<ApplicationDetail>();
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_ApplicationById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_ApplicationId", applicationId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            applicationDetailList.Add(new ApplicationDetail()
                            {
                                ApplicationId = Convert.ToInt16(reader["Application Id"]),
                                ApplicationStatusId = Convert.ToInt16(reader["applicationStatusId"]),
                                ApplicationStatus = reader["Application Status"].ToString(),
                                ApplicationTypeId = Convert.ToInt16(reader["applicationTypeId"]),
                                ApplicationType = reader["Application Type"].ToString(),
                                CustomerName = reader["Customer Name"].ToString()
                            });
                        }
                    }
                }
                conn.Close();
            }
            return applicationDetailList;
        }
    }
}