using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using MVCWebServer.Models;

namespace MVCWebServer.Controllers
{
    public class SeeFriendsController : Controller
    {
        public IActionResult Index(User userModel)
        {
            using (var connection = new SqliteConnection("" +
              new SqliteConnectionStringBuilder
              {
                  DataSource = "MVCDB.db"
              }))
            {

                List<int> pendingIDs = new List<int>();
                List<int> acceptedIDs = new List<int>();
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    int userid1 = 0;
                    int userid2 = 0;
                    string pending = "";
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
                    selectCommand.CommandText = "SELECT user_id_link1 FROM Friends WHERE status = '" + 0 + "' AND user_id_link2 = '" + userid1 + "'";
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pendingIDs.Add(reader.GetInt16(0));
                        }
                    }
                    for (int i = 0; i < pendingIDs.Count; i++)
                    {
                        selectCommand.Transaction = transaction;
                        selectCommand.CommandText = "SELECT username FROM Users WHERE userid = '" + pendingIDs[i] + "'";
                        using (var reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                userModel.currentPending.Add(reader.GetString(0));

                                Debug.WriteLine("Message : " + userModel.currentPending[i]);
                            }
                        }
                    }

                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "SELECT user_id_link1 FROM Friends WHERE status = '" + 1 + "' AND user_id_link2 = '" + userid1 + "'";
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            acceptedIDs.Add(reader.GetInt16(0));
                        }
                    }
                    for (int i = 0; i < acceptedIDs.Count; i++)
                    {
                        selectCommand.Transaction = transaction;
                        selectCommand.CommandText = "SELECT username FROM Users WHERE userid = '" + acceptedIDs[i] + "'";
                        using (var reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                userModel.currentFriends.Add(reader.GetString(0));

                                Debug.WriteLine("Message : " + userModel.currentFriends[i]);
                            }
                        }
                    }

                }
            }
            return View(userModel);
        }
        [HttpPost]
        public IActionResult AcceptFriend(User userModel, IFormCollection form)
        {

            Debug.WriteLine("TO ADD : " + userModel.toAdd);
            Debug.WriteLine("TO ADD : " + form["request"].ToString());
            userModel.toAdd = form["request"].ToString();
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
                    string pending = "";
                    var selectCommand = connection.CreateCommand();
                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "SELECT userid FROM users WHERE username = '" + userModel.username + "'";
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userid1 = reader.GetInt16(0);
                            Debug.WriteLine("User ID to ADD : " + userid1);
                        }


                    }
                    selectCommand.Transaction = transaction;
                    Debug.WriteLine("HERE: " + userModel.toAdd);
                    selectCommand.CommandText = "SELECT userid FROM users WHERE username = '" + userModel.toAdd + "'";
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userid2 = reader.GetInt16(0);
                            Debug.WriteLine("TO ADD USER ID : " + userid2);
                        }
                    }
                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "UPDATE Friends Set user_id_link1 ='" + userid2 + "', user_id_link2 = '" + userid1 +
                        "', status = '" + 1 + "'  WHERE user_id_link1 ='" + userid2 + "' AND user_id_link2 ='" + userid1 + "'";
                    selectCommand.ExecuteNonQuery();

                    var insertCommand = connection.CreateCommand();
                    insertCommand.Transaction = transaction;
                    insertCommand.CommandText = "INSERT INTO Friends ( user_id_link1,user_id_link2, status ) VALUES ( $userid,$userid_from, $status )";
                    insertCommand.Parameters.AddWithValue("$userid", userid1);
                    insertCommand.Parameters.AddWithValue("$userid_from", userid2);
                    insertCommand.Parameters.AddWithValue("$status", 1);
                    insertCommand.ExecuteNonQuery();

                    transaction.Commit();
                }



            }
            return View(userModel);
        }

        [HttpPost]
        public IActionResult MessageFriend(User userModel, IFormCollection form)
        {
            Debug.WriteLine("TO ADD : " + userModel.toAdd);
            Debug.WriteLine("TO ADD : " + form["request"].ToString());
            userModel.toAdd = form["request"].ToString();
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
                    string pending = "";
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
                    Debug.WriteLine("HERE: " + userModel.toAdd);
                    selectCommand.CommandText = "SELECT userid FROM users WHERE username = '" + userModel.toAdd + "'";
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userid2 = reader.GetInt16(0);
                            Debug.WriteLine("TO ADD USER ID : " + userid2);
                        }
                    }
                    selectCommand.Transaction = transaction;
                 
                        selectCommand.Transaction = transaction;
                        selectCommand.CommandText = "SELECT message FROM old_messages WHERE userid = '" + userid1 + "' AND user_id_from = '" + userid2+"'";
                        using (var reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                userModel.currentMessages.Add(reader.GetString(0));
                            }
                        }

                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "SELECT message FROM old_messages WHERE userid = '" + userid2 + "' AND user_id_from = '" + userid1 + "'";
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userModel.theirMessages.Add(reader.GetString(0));
                        }
                    }

                }



            }
            return View(userModel);
        }

        [HttpPost]
        public IActionResult SendMessage(User userModel, IFormCollection form)
        {
            userModel.toAdd = form["request"];
            Debug.WriteLine("Message sent: " + userModel.messageToSend);
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
                    string pending = "";
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
                    Debug.WriteLine("HERE: " + userModel.toAdd);
                    selectCommand.CommandText = "SELECT userid FROM users WHERE username = '" + userModel.toAdd + "'";
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userid2 = reader.GetInt16(0);
                            Debug.WriteLine("TO ADD USER ID : " + userid2);
                        }
                    }
                    var insertCommand = connection.CreateCommand();
                    insertCommand.Transaction = transaction;
                    insertCommand.CommandText = "INSERT INTO old_messages ( userid, message, user_id_from ) VALUES ( $userid, $message, $userid_from )";
                    insertCommand.Parameters.AddWithValue("$userid", userid1);
                    insertCommand.Parameters.AddWithValue("$userid_from", userid2);
                    insertCommand.Parameters.AddWithValue("$message", userModel.messageToSend);
                    insertCommand.ExecuteNonQuery();

                    transaction.Commit();
                }
                return View(userModel);
            }
        }
    }
}