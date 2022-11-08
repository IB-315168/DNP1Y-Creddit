using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class AuthService : IAuthService
    {
        private readonly IUserDAO userDAO;

        public AuthService(IUserDAO userDAO)
        {
            this.userDAO = userDAO;
        }

        public async Task<User> LoginAsync(UserLoginDTO dto)
        {
            ValidateUsername(dto.UserName);

            User? user = await userDAO.GetByUsernameAsync(dto.UserName);

            if(user == null)
            {
                throw new Exception("User not found");
            }

            if(!user.Password.Equals(dto.Password))
            {
                throw new Exception("Password incorrect");
            }

            return user;
        }

        public void ValidateUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new Exception("Username must not be empty");
            }
        }
    }
}
