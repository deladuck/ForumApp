using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models {
    public class RegisterModel {
        private string email;

        private string username;

        private string password;

        private string passwordConfirm;

        [Required]
        public string Email { get => email; set => email = value; }

        [Required]
        public string Username { get => username; set => username = value; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get => password; set => password = value; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get => passwordConfirm; set => passwordConfirm = value; }
    }
}