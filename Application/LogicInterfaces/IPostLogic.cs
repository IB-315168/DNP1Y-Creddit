﻿using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.LogicInterfaces
{
    public interface IPostLogic
    {
        Task<Post> CreateAsync(PostCreationDTO postToCreate);
        Task<Post> GetByIdAsync(int? id);
        Task<IEnumerable<Post>> GetAllAsync();
        Task<IEnumerable<Post>> GetByUserIdAsync(int id);
    }
}
