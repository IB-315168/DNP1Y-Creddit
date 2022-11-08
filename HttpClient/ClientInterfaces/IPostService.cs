using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClients.ClientInterfaces
{
    public interface IPostService
    {
        Task<Post> CreateAsync(PostCreationDTO dto);
        Task<ICollection<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(int id);
        Task<ICollection<Post>> GetAllByUserIdAsync(int id);
    }
}
