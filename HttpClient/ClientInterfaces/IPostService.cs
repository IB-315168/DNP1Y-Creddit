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
        Task<ICollection<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(int id);
    }
}
