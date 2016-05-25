using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chirper.API.Models
{
    public class Post
    {
        //Primary key
        public int PostId { get; set; }
        public string UserId { get; set; }

        //Fields relevant to Post
        public DateTime CreatedDate { get; set; }
        public string Text { get; set; }
        public int LikeCount { get; set; }

        //Relationship fields
        public virtual ChirperUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}