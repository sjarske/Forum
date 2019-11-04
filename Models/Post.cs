using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Post
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
