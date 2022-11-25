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
        public User Creator { get; private set; }
        public Post Post { get; private set; }
        public string Body { get; set; }
        public string CreatedDate { get; set; }

        public Comment(User creator, Post post)
        {
            Creator = creator;
            Post = post;
        }

        private Comment() { }
    }
}
