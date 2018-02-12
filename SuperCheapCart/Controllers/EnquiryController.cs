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

        [Route("api/saveEnquiry")]
        [HttpPost]
        public IList<Enquiry> SaveEnquiry([FromBody] Enquiry enquiry)
        {
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                int myoutput = 0;
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("save_Enquiry", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@_Name", enquiry.Name);
                    cmd.Parameters.AddWithValue("@_ContactNumber", enquiry.ContactNumber);
                    cmd.Parameters.AddWithValue("@_LoanAmt", enquiry.LoanAmt);
                    cmd.Parameters.AddWithValue("@_Comments", enquiry.Comments);
                    cmd.Parameters.AddWithValue("@_Tennure", enquiry.Tennure);
                    cmd.Parameters.AddWithValue("@_EnquiryId", 1).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    myoutput = Convert.ToInt16(cmd.Parameters["@_EnquiryId"].Value);
                }
                //add into customer, create application and insert into application history
                using (MySqlCommand cmd = new MySqlCommand("save_Application", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@_Name", enquiry.Name);
                    cmd.Parameters.AddWithValue("@_HomeAddress", enquiry.customer.HomeAddress);
                    cmd.Parameters.AddWithValue("@_OfficeAddress", enquiry.customer.OfficeAddress);
                    cmd.Parameters.AddWithValue("@_HomeContact", enquiry.customer.HomeContact);
                    cmd.Parameters.AddWithValue("@_OfficeContact", enquiry.customer.OfficeContact);
                    cmd.Parameters.AddWithValue("@_EnquiryId", myoutput); // this is generated from parameter above
                    cmd.Parameters.AddWithValue("@_ValidFrom", DateTime.Now);
                    //// for application detail table
                    cmd.Parameters.AddWithValue("@_ApplicationStatusId", 1);
                    cmd.Parameters.AddWithValue("@_ApplicationTypeId", enquiry.customer.ApplicationTypeId);
                    cmd.Parameters.AddWithValue("@_Comments", enquiry.Comments);
                    cmd.Parameters.AddWithValue("@_CreatedBy", "Ashok"); // this must be default in database.
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return getAllEnquiry(null);
        }
    }
}