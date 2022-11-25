using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public User Creator { get; private set;  }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Created { get; set; }

        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; }

        public Post(User creator)
        {
            Creator = creator;
        }

        private Post() { }
    }
}
