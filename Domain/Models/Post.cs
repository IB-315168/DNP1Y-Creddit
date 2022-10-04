using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int CreatorId { get; }
        public string Title { get; }
        public string Body { get; }

        public Post(int creatorId, string title, string body)
        {
            CreatorId = creatorId;
            Title = title;
            Body = body;
        }
    }
}
