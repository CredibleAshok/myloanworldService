using myloanworldService.common;
using myloanworldService.Dto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MyLoanWorldService.Controllers
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
                using (MySqlCommand cmd = new MySqlCommand((@"SELECT apd.applicationId as 'Application Id'
    ,apd.applicationStatusId
    ,aps.name as 'Application Status'
    ,apd.applicationTypeId
    ,apt.name as 'Application Type'
    ,e.name as 'Customer Name'
    ,apd.creationDate as 'Application Date'
    FROM `myloanworld`.`applicationDetail` as apd
	left outer join `myloanworld`.`enquiry` as e on e.enquiryId = apd.enquiryId
    join `myloanworld`.`applicationStatus` as aps on aps.applicationStatusId = apd.applicationStatusId
    join `myloanworld`.`applicationType` as apt on apt.applicationTypeId = apd.applicationTypeId " + conditons), conn))
                {
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
                                CustomerName = reader["Customer Name"].ToString(),
                                CreationDate = Convert.ToDateTime(reader["Application Date"])
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
            string query = "";
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
                if (conditionList[0].IndexOf("CustomerName=") > -1)
                {
                    query += "e.name='" + searchFilter.CustomerName + "'";
                }
                else if (conditionList[0].IndexOf("EnquiryId") > -1)
                {
                    query += "apd.enquiryId=" + searchFilter.EnquiryId;
                }
                else
                {
                    query += conditionList[0];
                }
            }
            string queryWithoutEnd = "";
            if (query.LastIndexOf(" or ") > -1)
            {
                return queryWithoutEnd = " where " + query.Substring(0, query.LastIndexOf(" or "));
            }
            else
            {
                if (query == "")
                {
                    return query;
                }
                else
                {
                    return " where " + query;
                }

            }
        }
    }
}
