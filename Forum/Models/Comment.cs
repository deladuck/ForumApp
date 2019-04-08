using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models {
    public class Comment {
        //incapsulated fields
        private int id;
        private string authorId;
        private string body;
        private int threadId;

        public Comment() {
        }

        //Constructor of the Class
        public Comment(int id, string authorId, string body, int threadId) {
            Id = id;
            AuthorId = authorId;
            Body = body;
            ThreadId = threadId;
        }
        //getters and setters for  incapsulated fields
        [Key]
        public int Id { get => id; set => id = value; }
        [Required]
        public string AuthorId { get => authorId; set => authorId = value; }
        [Required]
        public string Body { get => body; set => body = value; }
        [Required]
        public int ThreadId { get => threadId; set => threadId = value; }
    }
}