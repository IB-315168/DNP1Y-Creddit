﻿using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.LogicInterfaces
{
    public interface ICommentLogic
    {
        Task<Comment> CreateAsync(CommentCreationDTO commentToCreate, int postId);
        Task<IEnumerable<Comment>> GetAllAsync(int id);
    }
}
