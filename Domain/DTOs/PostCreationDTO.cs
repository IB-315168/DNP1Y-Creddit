using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class PostCreationDTO
    {
        public string Title { get; }
        public int CreatorId { get;  }
        public string Body { get; }
        public string Created { get; }

        public PostCreationDTO(int creatorId, string title, string body)
        {
            CreatorId = creatorId;
            Title = title;
            Body = body;
            Created = DateTime.Now.ToString("F");
        }
    }
}
