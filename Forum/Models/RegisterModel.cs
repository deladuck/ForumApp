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
        [MaxLength(20, ErrorMessage = "Максимум 20 символов")]
        [MinLength(5, ErrorMessage = "Минимум 5 символов")]
        public string Username { get => username; set => username = value; }

        [Required]
        [MinLength(6, ErrorMessage = "Минимум 5 символов")]
        [DataType(DataType.Password)]
        public string Password { get => password; set => password = value; }

        [Required]
        [MinLength(6, ErrorMessage = "Минимум 5 символов")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get => passwordConfirm; set => passwordConfirm = value; }
    }
}