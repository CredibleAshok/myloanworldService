using myloanworldService.Dto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using myloanworldService.common;

namespace SuperCheapCart.Controllers
{
    public class MenusController : ApiController
    {
        ConnectionMaker connection = new ConnectionMaker();
        [Route("api/getMenusList")]
        [HttpGet]
        public IList<Menus> getMenusList()
        {
            List<Menus> menusList = new List<Menus>();
            string query = @"SELECT * FROM myloanworld.menus";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                menusList.Add(new Menus()
                                {
                                    MenuId = Convert.ToInt16(reader["menuId"]),
                                    Name = reader["name"].ToString(),
                                    //SortOrder = Convert.ToInt16(reader["sortOrder"]),
                                    //ParentMenu = Convert.ToInt16(reader["parentMenu"]),
                                    Icon = reader["icon"].ToString(),
                                    Sref = reader["sref"].ToString()
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
            return menusList;
        }
    }
}