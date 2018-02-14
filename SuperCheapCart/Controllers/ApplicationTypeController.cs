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
            List<ApplicationTypeDto> applicationTypeList = new List<ApplicationTypeDto>();
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM myloanworld.applicationType", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            applicationTypeList.Add(new ApplicationTypeDto()
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
            return applicationTypeList;
        }

        [Route("api/saveApplicationType")]
        [HttpPost]
        public string SaveApplicationType([FromBody] ApplicationTypeDto applicationType)
        {
            string result = "";
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                string spName = "save_ApplicationType";
                using (MySqlCommand cmd = new MySqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@_Name", applicationType.name);
                    cmd.Parameters.AddWithValue("@_DescText", applicationType.descText);
                    cmd.Parameters.AddWithValue("@_Href", applicationType.href);
                    cmd.Parameters.AddWithValue("@_Icon", applicationType.icon);
                    cmd.Parameters.AddWithValue("@_Sref", applicationType.sref);
                    cmd.Parameters.AddWithValue("@_Localhref", applicationType.localhref);
                    cmd.Parameters.AddWithValue("@_UpdatedBy", applicationType.updatedBy);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                result = "Success";
            }
            return result;
        }

        [Route("api/updateApplicationType")]
        [HttpPost]
        public string UpdateApplicationType([FromBody] ApplicationTypeDto applicationType)
        {
            string result = "";
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                string spName = "update_ApplicationType";
                using (MySqlCommand cmd = new MySqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@_Name", applicationType.name);
                    cmd.Parameters.AddWithValue("@_DescText", applicationType.descText);
                    cmd.Parameters.AddWithValue("@_Href", applicationType.href);
                    cmd.Parameters.AddWithValue("@_Icon", applicationType.icon);
                    cmd.Parameters.AddWithValue("@_Sref", applicationType.sref);
                    cmd.Parameters.AddWithValue("@_Localhref", applicationType.localhref);
                    cmd.Parameters.AddWithValue("@_UpdatedBy", applicationType.updatedBy);
                    cmd.Parameters.AddWithValue("@_ApplicationTypeId", applicationType.applicationTypeId);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                result = "Success";
            }
            return result;
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