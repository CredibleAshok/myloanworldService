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
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM myloanworld.myLoanWorldUser where userName='" + user.UserName + "' and accessKeyCode ='" + user.AccessKeyCode + "'", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userList.Add(new User()
                            {
                                UserName = reader["userName"].ToString()
                                ,EnquiryId = Convert.ToInt16(reader["enquiryId"])
                                //.AccessKeyCode = reader["accessKeyCode"].ToString()
                            });
                        }
                    }
                }
                conn.Close();
            }
            return userList;
        }
    }
}