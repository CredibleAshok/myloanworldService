using myloanworldService.common;
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
                [Route("api/getApplicationList")]
        [HttpGet]
        public IList<ApplicationDetail> getApplication([FromUri] ApplicationDetail searchFilter)
        {
            string conditons = "";
            if (searchFilter != null)
            {
                conditons = makeQuery(searchFilter);
            }

            List<ApplicationDetail> applicationDetailList = new List<ApplicationDetail>();
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand((@"SELECT apd.applicationId, apd.applicationStatusId,
                                                              apd.applicationTypeId, apd.customerId  FROM myloanworld.applicationDetail as apd " + conditons), conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            applicationDetailList.Add(new ApplicationDetail()
                            {
                                ApplicationId = Convert.ToInt16(reader["applicationId"]),
                                ApplicationStatusId = Convert.ToInt16(reader["applicationStatusId"]),
                                //ApplicationStatus = reader["Application Status"].ToString(),
                                ApplicationTypeId = Convert.ToInt16(reader["applicationTypeId"]),
                                //ApplicationType = reader["Application Type"].ToString(),
                                //CustomerName = reader["Customer Name"].ToString()
                            });
                        }
                    }
                }
                conn.Close();
            }
            return applicationDetailList;
        }

        private string makeQuery(ApplicationDetail searchFilter)
        {
            IList<string> conditionList = new List<string>();
            string query = "where ";
            foreach (var prop in searchFilter.GetType().GetProperties())
            {
                if (prop.GetValue(searchFilter, null) != null)
                {
                    if ((prop.PropertyType.FullName == "System.Int32") && ((int)prop.GetValue(searchFilter, null) != 0))
                    {
                        conditionList.Add(prop.Name + "=" + prop.GetValue(searchFilter, null));
                    }
                    else if ((prop.PropertyType.FullName == "System.String") && (prop.GetValue(searchFilter, null).ToString() != ""))
                    {
                        conditionList.Add(prop.Name + "='" + prop.GetValue(searchFilter, null) + "'");
                    }
                }
            }
            if (conditionList.Count > 1)
            {
                foreach (string condition in conditionList)
                {
                    query += condition + " or ";
                }
            }
            else if (conditionList.Count == 1)
            {
                query += conditionList[0];
            }
            string queryWithoutEnd = query.Substring(0, query.LastIndexOf(" or "));
            return queryWithoutEnd;
        }
    }
}
