using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using MVCWebServer.Models;

namespace MVCWebServer.Controllers
{
    public class AddFriendController : Controller
    {
        public IActionResult Index(User userModel)
        {
            return View(userModel);
        }

        [RequireHttps]
        [HttpPost]
        public IActionResult SendRequest(User userModel)
        {
            using (var connection = new SqliteConnection("" +
               new SqliteConnectionStringBuilder
               {
                   DataSource = "MVCDB.db"
               }))
            {
                connection.Open();



                using (var transaction = connection.BeginTransaction())
                {
                    int userid1 = 0;
                    int userid2 = 0;
                    var selectCommand = connection.CreateCommand();
                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "SELECT userid FROM users WHERE username = '" + userModel.username + "'";
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userid1 = reader.GetInt16(0);
                            Debug.WriteLine("Message : " + userid1);
                        }
                    }

                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "SELECT userid FROM users WHERE username = '" + userModel.toAdd + "'";
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userid2 = reader.GetInt16(0);
                            Debug.WriteLine("Message : " + userid2);
                        }
                    }
          
                    if (userid2 == 0)
                    {
                        Debug.WriteLine("NOT FOUND!!! : " + userid2);
                        ViewData["Succ"] = "-1";
                    }
                    else
                    {
                        var insertCommand = connection.CreateCommand();
                        insertCommand.Transaction = transaction;
                        insertCommand.CommandText = "INSERT INTO Friends ( user_id_link1, user_id_link2 )" +
                            " VALUES ( $user_id_link1, $user_id_link2 )";

                        insertCommand.Parameters.AddWithValue("$user_id_link1", userid1);
                        insertCommand.Parameters.AddWithValue("$user_id_link2", userid2);
                        insertCommand.ExecuteNonQuery();
                        ViewData["Succ"] = "0";

                        transaction.Commit();
                    }
                }
            }

            return View(userModel);
        }
    }
}