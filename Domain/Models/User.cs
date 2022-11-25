using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string joinedOn { get; set; }

        public User(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        private User() { }

        [JsonIgnore]
        public ICollection<Post> Posts { get; set; }
        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; }
    }
}
