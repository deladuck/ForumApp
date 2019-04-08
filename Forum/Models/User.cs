using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Forum.Models {
    public class User {
        private int userId;
        private string username;
        private int role;

        [Key]
        public int UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public int Role { get => role; set => role = value; }
    }
}