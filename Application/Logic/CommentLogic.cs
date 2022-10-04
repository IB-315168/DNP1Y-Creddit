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
    public class CommentLogic : ICommentLogic
    {
        private readonly ICommentDAO commentDAO;

        public CommentLogic(ICommentDAO commentDAO)
        {
            this.commentDAO = commentDAO;
        }

        public async Task<Comment> CreateAsync(CommentCreationDTO commentToCreate, int postId)
        {
            ValidateData(commentToCreate);

            Comment toCreate = new Comment()
            {
                CreatorId = 1,
                PostId = postId,
                Body = commentToCreate.Body,
            };

            Comment created = await commentDAO.CreateAsync(toCreate);
            return created;
        }

        private void ValidateData(CommentCreationDTO commentToCreate)
        {
            string body = commentToCreate.Body;

            if(string.IsNullOrEmpty(body))
            {
                throw new Exception("Comment body must not be empty.");
            }
        }
    }
}
