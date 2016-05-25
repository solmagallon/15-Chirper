using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chirper.API.Models
{
    public class Comment
    {
        //Primary key
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }

        //Fields relevant to Post
        public DateTime CreatedDate { get; set; }
        public string Text { get; set; }

        //Relationship field
        public virtual Post Post { get; set; }
        public virtual ChirperUser User { get; set; }


    }
}