﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models {
    public class Thread {
        //incapsulated fields
        private int id;
        private string subject;
        private string description;
        private string author;

        public Thread() {
        }

        //Constructor of the Class
        public Thread(int id, string subject, string description, string author) {
            Id = id;
            Subject = subject;
            Description = description;
            Author = author;
        }

        //getters and setters for incapsulated fields
        [Key]
        public int Id { get => id; set => id = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Description { get => description; set => description = value; }
        public string Author { get => author; set => author = value; }
        
    }
}