using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDAO userDAO;

        public UserLogic(IUserDAO userDAO)
        {
            this.userDAO = userDAO;
        }

        public async Task<User> CreateAsync(UserCreationDTO userToCreate)
        {
            User? existing = await userDAO.GetByUsernameAsync(userToCreate.UserName);

            if (existing != null)
                throw new Exception("Username already taken!");

            ValidateData(userToCreate);
            User toCreate = new User
            {
                UserName = userToCreate.UserName,
                Password = userToCreate.Password
            };

            User created = await userDAO.CreateAsync(toCreate);

            return created;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            User? existing = await userDAO.GetByIdAsync(id);

            if (existing == null)
                throw new Exception("User does not exist");

            return existing;
        }

        private void ValidateData(UserCreationDTO userToCreate)
        {
            string userName = userToCreate.UserName;
            string password = userToCreate.Password;

            if (userName == null || userName.Length < 3) { throw new Exception("Username must consist of minimum 3 characters."); }
            if(password == null || password.Length < 8) { throw new Exception("Password must have minimum 8 characters."); }
        }
    }
}
