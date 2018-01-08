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

namespace myloanworldService.Controllers
{ 
    public class EnquiryController : ApiController
    {
        public string MyConnectionString = ConfigurationManager.AppSettings["Environment"] =="local"? ConfigurationManager.AppSettings["LocalMYSqlConnectionString"] : ConfigurationManager.AppSettings["MYSqlConnectionString"];

        [Route("api/getEnquiry")]
        [HttpGet]
        public IList<EnquiryDetailDto> GetEnquiry()
        {
            List<EnquiryDetailDto> enquiryList = new List<EnquiryDetailDto>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(MyConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM myloanworld.enquirydetail", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                enquiryList.Add(new EnquiryDetailDto()
                                {
                                    IdenquiryDetailId = Convert.ToInt16(reader["idenquiryDetailId"]),
                                    Name = reader["name"].ToString(),
                                    ContactNumber = reader["contactNumber"].ToString(),
                                    LoanAmt = Convert.ToInt16(reader["loanAmt"]),
                                    Comments = reader["comments"].ToString()
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
            return enquiryList;
        }

        [Route("api/saveEnquiry")]
        [HttpPost]
        public IList<EnquiryDetailDto> SaveEnquiry(EnquiryDetailDto enquiry)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(MyConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO `myloanworld`.`enquirydetail` (`name`,`contactNumber`,`loanAmt`,`comments`) VALUES (@valueToName,@valueToContactNumber,@valueToLoanAmt,@valueToComments);", conn))
                    {
                        cmd.Parameters.AddWithValue("@valueToName", enquiry.Name);
                        cmd.Parameters.AddWithValue("@valueToContactNumber", enquiry.ContactNumber);
                        cmd.Parameters.AddWithValue("@valueToLoanAmt", enquiry.LoanAmt);
                        cmd.Parameters.AddWithValue("@valueToComments", enquiry.Comments);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
            }
            return GetEnquiry();
        }
    }
}