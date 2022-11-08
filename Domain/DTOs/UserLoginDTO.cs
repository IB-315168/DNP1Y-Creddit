using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class UserLoginDTO
    {
        public string UserName { get; }
        public string Password { get; }

        public UserLoginDTO(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
