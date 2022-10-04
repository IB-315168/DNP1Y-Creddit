using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int CreatorId { get; }
        public int PostId { get; }
        public string Body { get; }

        public Comment(int creatorId, int postId, string body)
        {
            CreatorId = creatorId;
            PostId = postId;
            Body = body;
        }
    }
}
