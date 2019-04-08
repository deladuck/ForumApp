using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models {
    public class LoginModel {
        private string username;
        private string password;

        [Required]
        public string Username { get => username; set => username = value; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get => password; set => password = value; }
    }
}