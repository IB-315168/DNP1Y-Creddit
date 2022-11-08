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
        private readonly IUserDAO userDAO;

        public CommentLogic(IUserDAO userDAO, ICommentDAO commentDAO)
        {
            this.commentDAO = commentDAO;
            this.userDAO = userDAO;
        }

        public async Task<Comment> CreateAsync(CommentCreationDTO commentToCreate, int postId)
        {
            ValidateData(commentToCreate);
            Console.WriteLine(commentToCreate);

            User? existing = await userDAO.GetByIdAsync(commentToCreate.CreatorId);

            if (existing == null)
            {
                throw new Exception("User does not exist.");
            }

            Comment toCreate = new Comment()
            {
                Creator = existing,
                PostId = postId,
                Body = commentToCreate.Body,
                CreatedDate = commentToCreate.Created
            };

            Comment created = await commentDAO.CreateAsync(toCreate);
            return created;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync(int id)
        {
            return await commentDAO.GetAllAsync(id);
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
