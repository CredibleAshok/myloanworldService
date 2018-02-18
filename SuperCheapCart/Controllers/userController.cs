using myloanworldService.common;
using MySql.Data.MySqlClient;
using SuperCheapCart.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SuperCheapCart.Dto
{
    public class UserController : ApiController
    {
        ConnectionMaker connection = new ConnectionMaker();

        [Route("api/getContactDetails")]
        [HttpGet]
        public IList<User> GetContactDetails()
        {
            List<User> userList = new List<User>();
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM myloanworld.contactDetails", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userList.Add(new User()
                            {
                                EmailList = reader["emailList"].ToString()
                                ,AddressList = reader["addressList"].ToString()
                            });
                        }
                    }
                }
                conn.Close();
            }
            return userList;
        }

        [Route("api/updateContactDetails")]
        [HttpPost]
        public string UpdateContactDetails([FromBody] User user) 
        {
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_contactDetails", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_EmailList", user.EmailList);
                    cmd.Parameters.AddWithValue("@_AddressList", user.AddressList);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return "updated";
        }

        [Route("api/getUser")]
        [HttpPost]
        public IList<User> GetUser([FromBody] User user)
        {
            List<User> userList = new List<User>();
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("authenticate_User", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@_AccessKeyCode", user.AccessKeyCode);
                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userList.Add(new User()
                            {
                                UserName = reader["User Name"].ToString(),
                                EnquiryId = Convert.ToInt16(reader["Enquiry Id"]),
                                CustomerId = Convert.ToInt16(reader["customer Id"]),
                                FeatureName = reader["Feature Name"].ToString()
                            });
                        }
                    }
                }
                conn.Close();
            }
            return userList;
        }

        [Route("api/createPassword")]
        [HttpPost]
        public string CreatePassword([FromBody] User user)
        {
            List<User> userList = new List<User>();
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("create_Password", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@_AccessKeyCode", user.AccessKeyCode);
                    cmd.ExecuteNonQuery();
                }
                // send email
                conn.Close();
                return "Your account is ready. You can login.";
            }
        }

        [Route("api/forgotPassword")]
        [HttpPost]
        public string ForgotPassword([FromBody] User user)
        {
            string UserPasssword = "";
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("forgot_Password", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@_UserPasssword", "").Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    UserPasssword = cmd.Parameters["@_UserPasssword"].Value.ToString();
                }
                conn.Close();
            }
            EmailSender enquiryEmailSender = new EmailSender("letusknow@myloanworld.com", "ashok.forklift@gmail.com", ("Your password is: " + UserPasssword), ("You password recovered!"));
            string enquiryEmailStatus = enquiryEmailSender.SendForgotPasswordEmailViaWebApi();
            return enquiryEmailStatus != null ? "Password sent to your registered email." : "error happened.";
        }
    }
}
