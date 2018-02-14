using myloanworldService.common;
using myloanworldService.Dto;
using MySql.Data.MySqlClient;
using SuperCheapCart.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SuperCheapCart.Controllers
{
    public class CustomerController : ApiController
    {
        ConnectionMaker connection = new ConnectionMaker();
        [Route("api/getCustomer")]
        [HttpPost]
        public IList<Customer> GetCustomer([FromBody] Customer customer)
        {
            List<Customer> customerList = new List<Customer>();
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM myloanworld.customer where name='" + customer.Name + "' and accessKeyCode ='" + customer.AccessKeyCode + "'", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customerList.Add(new Customer()
                            {
                                CustomerId = Convert.ToInt16(reader["customerId"]),
                                Name = reader["name"].ToString(),
                                EnquiryId = Convert.ToInt16(reader["enquiryId"]),
                                HomeAddress = reader["homeAddress"].ToString(),
                                OfficeAddress = reader["officeAddress"].ToString(),
                                AccessKeyCode = reader["accessKeyCode"].ToString()
                            });
                        }
                    }
                }
                conn.Close();
            }
            return customerList;
        }

        [Route("api/getCustomerByEnquiryId")]
        [HttpGet]
        public IList<Customer> GetCustomerByEnquiryId([FromUri] int enquiryId)
        {
            List<Customer> customerList = new List<Customer>();
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_Customer", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_EnquiryId", enquiryId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customerList.Add(new Customer()
                            {
                                CustomerId = Convert.ToInt16(reader["Customer Id"]),
                                FirstName = reader["First Name"].ToString(),
                                MiddleName = reader["Middle Name"].ToString(),
                                LastName = reader["Last Name"].ToString(),
                                EnquiryId = Convert.ToInt16(reader["Enquiry Id"])
                            });
                        }
                    }
                }
                conn.Close();
            }
            return customerList;
        }
        // these need to be ported in respective files. Start
        [Route("api/updateApplicationStatus")]
        [HttpPost]
        public string UpdateApplicationStatus([FromBody] ApplicationStatus applicationStatus)
        {
            string result = "";
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                string spName = "update_applicationStatus";
                using (MySqlCommand cmd = new MySqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@_Name", applicationStatus.FirstName);
                    cmd.Parameters.AddWithValue("@_ApplicationStatusId", applicationStatus.ApplicationStatusId);
                    cmd.Parameters.AddWithValue("@_UpdatedBy", applicationStatus.CreatedBy);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                result = "Success";
            }
            return result;
        }
                [Route("api/saveApplicationStatus")]
        [HttpPost]
        public string SaveApplicationStatus([FromBody] ApplicationStatus applicationStatus)
        {
            string result = "";
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                string spName = "save_applicationStatus";
                using (MySqlCommand cmd = new MySqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@_Name", applicationStatus.FirstName);
                    cmd.Parameters.AddWithValue("@_UpdatedBy", applicationStatus.CreatedBy);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                result = "Success";
            }
            return result;
        }
        // for application type
                [Route("api/saveApplicationType")]
        [HttpPost]
        public string SaveApplicationType([FromBody] ApplicationType applicationType)
        {
            string result = "";
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                string spName = "save_ApplicationType";
                using (MySqlCommand cmd = new MySqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@_Name", applicationType.FirstName);
                    cmd.Parameters.AddWithValue("@_DescText", applicationType.DescText);
                    cmd.Parameters.AddWithValue("@_Href", applicationType.Href);
                    cmd.Parameters.AddWithValue("@_Icon", applicationType.Icon);
                    cmd.Parameters.AddWithValue("@_Sref", applicationType.Sref);
                    cmd.Parameters.AddWithValue("@_Localhref", applicationType.Localhref);
                    cmd.Parameters.AddWithValue("@_Name", applicationType.FirstName);
                    cmd.Parameters.AddWithValue("@_UpdatedBy", applicationType.CreatedBy);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                result = "Success";
            }
            return result;
        }
        
                [Route("api/updateApplicationType")]
        [HttpPost]
        public string UpdateApplicationType([FromBody] ApplicationType applicationType)
        {
            string result = "";
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                string spName = "update_ApplicationType";
                using (MySqlCommand cmd = new MySqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@_Name", applicationType.FirstName);
                    cmd.Parameters.AddWithValue("@_DescText", applicationType.DescText);
                    cmd.Parameters.AddWithValue("@_Href", applicationType.Href);
                    cmd.Parameters.AddWithValue("@_Icon", applicationType.Icon);
                    cmd.Parameters.AddWithValue("@_Sref", applicationType.Sref);
                    cmd.Parameters.AddWithValue("@_Localhref", applicationType.Localhref);
                    cmd.Parameters.AddWithValue("@_Name", applicationType.FirstName);
                    cmd.Parameters.AddWithValue("@_UpdatedBy", applicationType.CreatedBy);
                    cmd.Parameters.AddWithValue("@_ApplicationTypeId", applicationType.ApplicationTypeId);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                result = "Success";
            }
            return result;
        }
        // these need to be ported in respective files. End
        
        [Route("api/updateCustomer")]
        [HttpPost]
        public string UpdateCustomer([FromBody] Customer customer)
        {
            string result = "";
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                string spName = "update_Customer";
                using (MySqlCommand cmd = new MySqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@_FirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@_MiddleName", customer.MiddleName);
                    cmd.Parameters.AddWithValue("@_LastName", customer.LastName);
                    cmd.Parameters.AddWithValue("@_HomeAddress", customer.HomeAddress);
                    cmd.Parameters.AddWithValue("@_OfficeAddress", customer.OfficeAddress);
                    cmd.Parameters.AddWithValue("@_HomeContact", customer.HomeContact);
                    cmd.Parameters.AddWithValue("@_OfficeContact", customer.OfficeContact);
                    cmd.Parameters.AddWithValue("@_EnquiryId", customer.EnquiryId);
                    cmd.Parameters.AddWithValue("@_ValidFrom", DateTime.Now);
                    // for application detail table
                    cmd.Parameters.AddWithValue("@_ApplicationStatusId", 1);
                    cmd.Parameters.AddWithValue("@_ApplicationTypeId", customer.ApplicationTypeId);
                    cmd.Parameters.AddWithValue("@_Comments", customer.Comments);
                    cmd.Parameters.AddWithValue("@_CreatedBy", customer.CreatedBy);
                    cmd.Parameters.AddWithValue("@_CustomerId", customer.CustomerId);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                result = "Success";
            }
            return result;
        }
    }
}
