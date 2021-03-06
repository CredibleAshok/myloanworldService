﻿using myloanworldService.common;
using myloanworldService.Dto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SuperCheapCart.Controllers
{
    public class ApplicationHistoryController : ApiController
    {
        ConnectionMaker connection = new ConnectionMaker();
        [Route("api/getApplicationHistoryById")]
        [HttpGet]
        public IList<ApplicationHistory> GetApplicationHistoryById([FromUri] int? applicationId)
        {
            List<ApplicationHistory> applicationHistoryList = new List<ApplicationHistory>();
            string query = "";
            if (applicationId != null)
            {
                query = @"SELECT aph.applicationId, aph.applicationStatusId, 
                            aps.name as 'applicationStatus',
                            aph.comments, aph.creationDate, aph.createdBy
                            FROM myloanworld.applicationHistory aph
                            join myloanworld.applicationStatus aps on aps.applicationStatusId = aph.applicationStatusId
                            where aph.applicationId = '" + applicationId + "'";
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                applicationHistoryList.Add(new ApplicationHistory()
                                {
                                    ApplicationId = Convert.ToInt16(reader["applicationId"]),
                                    ApplicationStatusId = Convert.ToInt16(reader["applicationStatusId"]),
                                    ApplicationStatus = reader["applicationStatus"].ToString(),
                                    Comments = reader["comments"].ToString(),
                                    CreationDate = Convert.ToDateTime(reader["creationDate"]),
                                    CreatedBy= reader["createdBy"].ToString()
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
            return applicationHistoryList;
        }

        [Route("api/changeApplicationStatus")]
        [HttpPost]
        public string ChangeApplicationStatus([FromBody] ApplicationHistory applicationHistory)
        {
            string result = "";
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                string spName = "change_Application_Status";
                using (MySqlCommand cmd = new MySqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@_ApplicationId", applicationHistory.ApplicationId);
                    cmd.Parameters.AddWithValue("@_ApplicationStatusId", applicationHistory.ApplicationStatusId);
                    cmd.Parameters.AddWithValue("@_Comments", applicationHistory.Comments);
                    cmd.Parameters.AddWithValue("@_CreatedBy", applicationHistory.CreatedBy);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                result = "Success";
            }
            return result;
        }
    }
}