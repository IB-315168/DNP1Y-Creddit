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
        public int CreatorId { get; set; }
        public int PostId { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; }

        public Comment()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
