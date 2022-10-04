using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAOInterfaces
{
    public interface IUserDAO
    {
        Task<User> CreateAsync(User user);
        Task<User?> GetByUsernameAsync(string userName);
    }
}
