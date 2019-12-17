using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebServer.Models
{
    public class User
    {
        [Key]
        public string username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool auth { get; set; } = false;
        public string messageToSend { get; set; }
        public string toAdd { get; set; }
        [NotMapped]
        public List<string> currentPending = new List<string>();
        [NotMapped]
        public List<string> currentFriends= new List<string>();
        [NotMapped]
        public List<string> currentMessages = new List<string>();
        [NotMapped]
        public List<string> theirMessages = new List<string>();
    }
}
