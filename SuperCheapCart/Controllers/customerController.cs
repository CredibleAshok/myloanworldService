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
        public string MyConnectionString = ConfigurationManager.AppSettings["Environment"] == "local" ? ConfigurationManager.AppSettings["LocalMYSqlConnectionString"] : ConfigurationManager.AppSettings["MYSqlConnectionString"];
        [Route("api/getCustomer")]
        [HttpPost]
        public IList<Customer> GetCustomer([FromBody] Customer customer)
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(MyConnectionString))
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
    }
}