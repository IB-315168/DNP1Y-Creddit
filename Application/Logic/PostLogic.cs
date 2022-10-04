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

        public PostLogic(IPostDAO postDAO)
        {
            this.postDAO = postDAO;
        }

        public async Task<Post> CreateAsync(PostCreationDTO postToCreate)
        {
            ValidateData(postToCreate);

            Post toCreate = new Post
            {
                CreatorId = 1,
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
    }
}
