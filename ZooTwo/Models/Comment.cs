using System;

namespace ZooTwo.Models
{
    public class Comment
    {
        public Int32 CommentID { get; set; }

        public String Content { get; set; }

        public Int32 LocationID { get; set; }
        public virtual Location Location { get; set; }
    }
}