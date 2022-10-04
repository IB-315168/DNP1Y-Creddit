using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAOInterfaces
{
    public interface IPostDAO
    {
        Task<Post> CreateAsync(Post post);
        Task<Post?> GetByIdAsync(int id);
    }
}
