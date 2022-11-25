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
    public class PostLogic : IPostLogic
    {
        private readonly IPostDAO postDAO;
        private readonly IUserDAO userDAO;

        public PostLogic(IPostDAO postDAO, IUserDAO userDAO)
        {
            this.postDAO = postDAO;
            this.userDAO = userDAO;
        }

        public async Task<Post> CreateAsync(PostCreationDTO postToCreate)
        {
            ValidateData(postToCreate);

            User? existing = await userDAO.GetByIdAsync(postToCreate.CreatorId);

            if(existing == null)
            {
                throw new Exception("User does not exist.");
            }

            Post toCreate = new Post(existing)
            {
                Created = postToCreate.Created,
                Title = postToCreate.Title,
                Body = postToCreate.Body,
            };

            Post created = await postDAO.CreateAsync(toCreate);
            return created;
        }

        private void ValidateData(PostCreationDTO postToCreate)
        {
            string title = postToCreate.Title;
            string body = postToCreate.Body;

            if(string.IsNullOrEmpty(title))
            {
                throw new Exception("Post must have a title");
            }

            if(string.IsNullOrEmpty(body))
            {
                throw new Exception("Post must have a body");
            }

            if(title.Length > 100)
            {
                throw new Exception("Title must not exceed 100 characters");
            }
        }

        public async Task<Post> GetByIdAsync(int? id)
        {
            if(id == null)
            {
                throw new Exception("Id must not be null to find the post");
            }

            Post? post = await postDAO.GetByIdAsync((int)id);

            if(post == null)
            {
                throw new Exception($"Post with {id} has not been found");
            }
            return post;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await postDAO.GetAllAsync();
        }

        public async Task<IEnumerable<Post>> GetByUserIdAsync(int id)
        {
            return await postDAO.GetByUserIdAsync(id);
        }
    }
}
