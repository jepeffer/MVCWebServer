using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebServer.Models
{
    public class User
    {
         [Key]
        public string username { get; set; }
        public string password;
    }
}
