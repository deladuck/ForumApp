using System;
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
        private string quickDescription;
        private string author;

        public Thread() {
        }

        //Constructor of the Class
        public Thread(int id, string subject, string description, string author) {
            Id = id;
            
            if (subject.Length > 99) {
                Subject = subject.Substring(0, 99);
            } else {
                Subject = subject;
            }

            Description = description;

            if (description.Length > 99) {
                QuickDescription = description.Substring(0, 99);//the same as description but max charachters are 100
            } else {
                QuickDescription = description;
            }
            
            Author = author;
        }

        //getters and setters for incapsulated fields
        [Key]
        public int Id { get => id; set => id = value; }

        [Required]
        public string Subject { get => subject; set => subject = value; }
        [Required]
        public string Description { get => description; set => description = value; }
        public string QuickDescription { get => quickDescription; set => quickDescription = value; }
        public string Author { get => author; set => author = value; }
        
    }
}