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
                                EnquiryId = reader["enquiryId"].ToString(),
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
        
        [Route("api/saveApplication")]
        [HttpPost]
        public string SaveApplication([FromBody] Customer customer)
        {
            string result = "";
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                string spName = "save_Application";
                using (MySqlCommand cmd = new MySqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@_Name", customer.Name);
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
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                result = "Success";
            }
            return result;
        }

        [Route("api/forgotPassword")]
        [HttpPost]
        public string ForgotPassword([FromBody] Customer customer)
        {
            string query = "SELECT accessKeyCode FROM customer where name='" + customer.Name + "'";
            //string emailStatus = emailsender.SendEmailViaWebApi();
            string accessCode = "";
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accessCode = reader["accessKeyCode"].ToString();
                        }
                    }
                }
                conn.Close();
            }
            return accessCode != null ? "Password sent to your registered email." : "error happened.";
        }

        [Route("api/createPassword")]
        [HttpPost]
        public string CreatePassword([FromBody] Customer customer)
        {
            List<Customer> customerList = new List<Customer>();
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM myloanworld.customer where name='" + customer.Name + "'", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customerList.Add(new Customer()
                            {
                                CustomerId = Convert.ToInt16(reader["customerId"]),
                                AccessKeyCode = reader["accessKeyCode"].ToString()
                            });
                        }
                    }
                }
                string query = "update customer set accessKeyCode='" + customer.AccessKeyCode + "' where name='" + customer.Name + "'";
                MySqlCommand cmdupdate = new MySqlCommand(query, conn);

                cmdupdate.ExecuteNonQuery();
                // send email
                conn.Close();
                return "Your account is ready. You can login.";
            }
        }
    }
}