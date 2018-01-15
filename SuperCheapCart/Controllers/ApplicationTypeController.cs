using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using myloanworldService.Dto;
using MySql.Data.MySqlClient;
using System.Configuration;
using myloanworldService.common;

namespace myloanworldService.Controllers
{
    public class ApplicationTypeController : ApiController
    {
        ConnectionMaker connection = new ConnectionMaker();

        [Route("api/getApplicationType")]
        [HttpGet]
        public IList<ApplicationTypeDto> GetApplicationType()
        {
            List<ApplicationTypeDto> enquiryList = new List<ApplicationTypeDto>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM myloanworld.applicationType", conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                enquiryList.Add(new ApplicationTypeDto()
                                {
                                    applicationTypeId = Convert.ToInt16(reader["applicationTypeId"]),
                                    name = reader["name"].ToString(),
                                    descText = reader["descText"].ToString(),
                                    href = reader["href"].ToString(),
                                    icon = reader["icon"].ToString(),
                                    sref = reader["sref"].ToString(),
                                    localhref = reader["localhref"].ToString(),
                                    //validFrom = Convert.ToDateTime(reader["validFrom"]),
                                    //validTo = Convert.ToDateTime(reader["validTo"]),
                                    //updatedDate = Convert.ToDateTime(reader["updatedDate"]),
                                    updatedBy = reader["updatedBy"].ToString()
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

        //[Route("api/saveEnquiry")]
        //[HttpPost]
        //public IList<ApplicationTypeDto> SaveEnquiry(ApplicationTypeDto enquiry)
        //{
        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(MyConnectionString))
        //        {
        //            conn.Open();
        //            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO `myloanworld`.`enquirydetail` (`name`,`contactNumber`,`loanAmt`,`comments`) VALUES (@valueToName,@valueToContactNumber,@valueToLoanAmt,@valueToComments);", conn))
        //            {
        //                cmd.Parameters.AddWithValue("@valueToName", enquiry.Name);
        //                cmd.Parameters.AddWithValue("@valueToContactNumber", enquiry.ContactNumber);
        //                cmd.Parameters.AddWithValue("@valueToLoanAmt", enquiry.LoanAmt);
        //                cmd.Parameters.AddWithValue("@valueToComments", enquiry.Comments);
        //                cmd.ExecuteNonQuery();
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //    }
        //    return GetEnquiry();
        //}
    }
}