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
        public IList<Menus> GetMenusList([FromUri] int roleId)
        {
            List<Menus> menusList = new List<Menus>();
            using (MySqlConnection conn = new MySqlConnection(connection.MySQLConnectionString))
            {
                conn.Open();
      
                using (MySqlCommand cmd = new MySqlCommand("get_menusByRole", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_RoleId", roleId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            menusList.Add(new Menus()
                            {
                                //MenuId = Convert.ToInt16(reader["menuId"]),
                                Name = reader["Menu Name"].ToString(),
                                IsManagement = Convert.ToBoolean(reader["Is Management"]),
                                //SortOrder = Convert.ToInt16(reader["sortOrder"]),
                                //ParentMenu = Convert.ToInt16(reader["parentMenu"]),
                                Icon = reader["Icon"].ToString(),
                                Sref = reader["sref"].ToString()
                            });
                        }
                    }
                }
                //add into customer, create application and insert into application history
                conn.Close();
            }
            return menusList;
        }
    }
}