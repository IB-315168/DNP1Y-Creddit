﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class UserCreationDTO
    {
        public string UserName { get; }
        public string Password { get; }
        public string JoinedOn { get; }

        public UserCreationDTO(string userName, string passWord)
        {
            UserName = userName;
            Password = passWord;
            JoinedOn = DateTime.Now.ToString("F");
        }
    }
}
