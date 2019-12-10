using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using MVCWebServer.Models;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace MVCWebServer.Controllers
{
    public class CreateUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewUser(User userModel)
        {
            string hash = "";
            if (ModelState.IsValid)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    hash = GetMd5Hash(md5Hash, userModel.Password);
                    Debug.WriteLine(userModel.username + " YEET " + userModel.Password);

                }
            }

            using (var connection = new SqliteConnection("" +
                new SqliteConnectionStringBuilder
                {
                    DataSource = "MVCDB.db"
                }))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var insertCommand = connection.CreateCommand();
                    insertCommand.Transaction = transaction;
                    insertCommand.CommandText = "INSERT INTO users ( username, password ) VALUES ( $username, $password )";
                    insertCommand.Parameters.AddWithValue("$username", userModel.username);
                    insertCommand.Parameters.AddWithValue("$password", hash);
                    insertCommand.ExecuteNonQuery();

                    transaction.Commit();
                }
                return View();
            }
        }

            static string GetMd5Hash(MD5 md5Hash, string input)
            {

                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }
    }