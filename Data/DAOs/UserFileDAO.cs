using Application.DAOInterfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAOs
{
    public class UserFileDAO : IUserDAO
    {
        private readonly FileContext context;

        public UserFileDAO(FileContext context) 
        {
            this.context = context;
        }
        public Task<User> CreateAsync(User user)
        {
            int id = 1;
            if(context.Users.Any())
            {
                id = context.Users.Max(u => u.Id);
                id++;
            }

            user.Id = id;

            context.Users.Add(user);
            context.SaveChanges();

            return Task.FromResult(user);
        }

        public Task<User?> GetByIdAsync(int id)
        {
            User? existing = context.Users.FirstOrDefault(u => u.Id == id);

            return Task.FromResult(existing);
        }

        public Task<User?> GetByUsernameAsync(string userName)
        {
            User? existing = context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(existing);
        }
    }
}
