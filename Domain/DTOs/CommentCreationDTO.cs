using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class CommentCreationDTO
    {

        public int CreatorId { get; }
        public string Body { get; set; }
        public string Created { get; }

        public CommentCreationDTO(int creatorId)
        {
            Created = DateTime.Now.ToString("F");
            CreatorId = creatorId;
        }
    }
}
