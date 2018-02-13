using myloanworldService.common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SuperCheapCart.Dto
{
    public class UserController : ApiController
    {
        ConnectionMaker connection = new ConnectionMaker();
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
                                UserName = reader["User Name"].ToString()
                                ,EnquiryId = Convert.ToInt16(reader["Enquiry Id"])
                                ,CustomerId = Convert.ToInt16(reader["customer Id"])
                                ,FeatureName = reader["Feature Name"].ToString()
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
            var AccessKeyCode = "";
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("forget_Password", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_UserName", user.UserName);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AccessKeyCode = reader["Access Key Code"].ToString();
                        }
                    }
                }
                conn.Close();
            }
            return AccessKeyCode != null ? "Password sent to your registered email." : "error happened.";
        }
    }
}