using Application.DAOInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcDataAccess.DAOs
{
    public class UserEfcDAO : IUserDAO
    {
        private readonly UPCContext context;

        public UserEfcDAO(UPCContext context)
        {
            this.context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            EntityEntry<User> newUser = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return newUser.Entity;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            User? existing = await context.Users.FindAsync(id);
            return existing;
        }

        public async Task<User?> GetByUsernameAsync(string userName)
        {
            User? existing = await context.Users.FirstOrDefaultAsync(u =>
                u.UserName.ToLower().Equals(userName.ToLower())
            );
            return existing;
        }
    }
}
