using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAOInterfaces
{
    public interface ICommentDAO
    {
        Task<Comment> CreateAsync(Comment comment);
    }
}
