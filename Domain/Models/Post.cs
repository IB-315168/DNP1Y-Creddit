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
        public int CreatorId { get; set;  }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Created { get; set; }

        
    }
}
