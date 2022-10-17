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
        public string Body { get; }
        public string Created { get; }

        public PostCreationDTO(string title, string body)
        {
            Title = title;
            Body = body;
            Created = DateTime.Now.ToString("F");
        }
    }
}
