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
            try
            {
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
            }
            catch (MySqlException ex)
            {
            }
            return customerList;
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