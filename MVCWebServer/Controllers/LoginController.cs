using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using MVCWebServer.Models;

namespace MVCWebServer.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckLogin(User userModel)
        {

            if (ModelState.IsValid)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, userModel.Password);

                    using (var connection = new SqliteConnection("" +
                    new SqliteConnectionStringBuilder
                    {
                        DataSource = "MVCDB.db"
                    }))
                    {
                        connection.Open();

                        using (var transaction = connection.BeginTransaction())
                        {
                            string password = "";
                            var selectCommand = connection.CreateCommand();
                            selectCommand.Transaction = transaction;
                            selectCommand.CommandText = "SELECT password FROM users WHERE username = '" + userModel.username + "'";
                            using (var reader = selectCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    password = reader.GetString(0);
                                    Debug.WriteLine("Message : " + password);
                                }
                            }
                            transaction.Commit();
                            Debug.WriteLine(hash + " " + password);
                            bool auth = hash.Equals(password);

                            if (auth)
                            {
                                userModel.auth = true;
                                return View(userModel);
                            }
                           
                        }
                    }
                }
            }
            return View(userModel);

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

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
