using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClients.ClientInterfaces
{
    public interface ICommentService
    {
        Task<Comment> CreateAsync(CommentCreationDTO dto, int id);
        Task<IEnumerable<Comment>> GetAllAsync(int id);
    }
}
