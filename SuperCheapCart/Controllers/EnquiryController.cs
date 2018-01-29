using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using myloanworldService.Dto;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Configuration;
using myloanworldService.common;

namespace myloanworldService.Controllers
{
    public class EnquiryController : ApiController
    {
        ConnectionMaker connection = new ConnectionMaker();

        [Route("api/getAllEnquiry")]
        [HttpGet]
        public IList<Enquiry> getAllEnquiry([FromUri] Enquiry searchFilter)
        {
            string conditons = "";
            if (searchFilter != null)
            {
                conditons = makeQuery(searchFilter);
            }

            List<Enquiry> enquiryList = new List<Enquiry>();
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(("SELECT * FROM myloanworld.enquiry " + conditons), conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            enquiryList.Add(new Enquiry()
                            {
                                EnquiryId = Convert.ToInt16(reader["enquiryId"]),
                                Name = reader["name"].ToString(),
                                ContactNumber = reader["contactNumber"].ToString(),
                                LoanAmt = ((reader["loanAmt"]) is DBNull) ? (int?)null:  Convert.ToInt16(reader["loanAmt"]),
                                Comments = reader["comments"].ToString()
                            });
                        }
                    }
                }
                conn.Close();
            }
            return enquiryList;
        }

        private string makeQuery(Enquiry searchFilter)
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
                    query += condition + " and ";
                }
            }
            else if (conditionList.Count == 1)
            {
                query += conditionList[0];
            }
            string queryWithoutEnd = query.Substring(0, query.LastIndexOf(" and "));
            return queryWithoutEnd;
        }

        [Route("api/saveEnquiry")]
        [HttpPost]
        public IList<Enquiry> SaveEnquiry(Enquiry enquiry)
        {
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO `myloanworld`.`enquiry` (`name`,`contactNumber`,`loanAmt`,`comments`,`creationDate`) VALUES (@valueToName,@valueToContactNumber,@valueToLoanAmt,@valueToComments, @valueToCreationDate);", conn))
                {
                    cmd.Parameters.AddWithValue("@valueToName", enquiry.Name);
                    cmd.Parameters.AddWithValue("@valueToContactNumber", enquiry.ContactNumber);
                    cmd.Parameters.AddWithValue("@valueToLoanAmt", enquiry.LoanAmt);
                    cmd.Parameters.AddWithValue("@valueToComments", enquiry.Comments);
                    cmd.Parameters.AddWithValue("@valueToCreationDate", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return getAllEnquiry(null);
        }
    }
}