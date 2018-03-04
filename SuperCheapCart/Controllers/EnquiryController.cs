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
using MyLoanWorldService.common;

namespace myloanworldService.Controllers
{
    public class EnquiryController : ApiController
    {
        private string FormatEmail(Enquiry enquiry, string userId, string type)
        {
            string linkToSetPassword = @"http://myloanworld.com/";
            if (type != "enquiry")
            {
                return @"<html><head></head><body>
                     <span><b>Congratulations! " + enquiry.Name + @"</b></span>
                     </br><span>Thanks for providing the opportunity to server you!</span>
                     </br><span>Your can view progress on your application by logging into application. Click this link to create 
                        your password. <a href='" + linkToSetPassword + @"'></a></span>
                    </br><span><b>Please note: Your userId is: " + userId + @"</b></ span > 
                     </body>
                     </html>";
            }
            else
            {
                return @"<html><head></head><body>
                     <span><b>Congratulations!</b></span>
                     </br><span>" + enquiry.Name + @"wants to get in touch with you!</span>
                     </br><h1>Details are as follows.</h1> 
<table style='width: 100%;border:2px solid blue;'><tr>
<td>Contact Number:</td><td><b>" + enquiry.ContactNumber + @"</b></td>
<td>Loan Amount:</td><td><b>" + enquiry.LoanAmt + @"</b></td>
<td>Comments:</td><td><b>" + enquiry.Comments + @"</b></td>
</tr></table>
                     </body>
                     </html>";
            }
            
        }
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
                                LoanAmt = ((reader["loanAmt"]) is DBNull) ? (double?)null : Convert.ToDouble(reader["loanAmt"]),
                                Comments = reader["comments"].ToString(),
                                CreationDate = Convert.ToDateTime(reader["creationDate"])
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
                query += conditionList[0];
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

        [Route("api/saveEnquiry")]
        [HttpPost]
        public string SaveEnquiry([FromBody] Enquiry enquiry)
        {
            int myoutput = 0;
            string userId = "";
            string contactUsEmail = "";

            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {

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
                    cmd.Parameters.AddWithValue("@_EmailId", enquiry.EmailId);
                    cmd.Parameters.AddWithValue("@_UserId", enquiry.UserId).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@_ContactUsEmail", enquiry.ContactUsEmail).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    userId = cmd.Parameters["@_UserId"].Value.ToString();
                    contactUsEmail = cmd.Parameters["@_ContactUsEmail"].Value.ToString();
                }
                conn.Close();
            }
            EmailSender enquiryEmailSender = new EmailSender("letusknow@myloanworld.com", contactUsEmail, FormatEmail(enquiry, userId, "enquiry"), ("New Enquiry - " + enquiry.Name));
            string enquiryEmailStatus = enquiryEmailSender.SendEnquiryDetailsEmailViaWebApi();
            EmailSender userIdEmailSender = new EmailSender("letusknow@myloanworld.com", enquiry.EmailId, FormatEmail(enquiry, userId, "userId"), ("User Id from My Loan World - " + userId));
            string userIdEmailStatus = userIdEmailSender.SendEnquiryDetailsEmailViaWebApi();
            return (enquiryEmailStatus != null || userIdEmailStatus != null) ? ("Congratulations! Enquiry Received!") : "Some Problem Happened!";
        }
    }
}