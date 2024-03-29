﻿using Application.DAOInterfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAOs
{
    public class PostFileDAO : IPostDAO 
    {
        private readonly FileContext context;

        public PostFileDAO(FileContext context)
        {
            this.context = context;
        }

        public Task<Post> CreateAsync(Post post)
        {
            int id = 1;
            if (context.Posts.Any())
            {
                id = context.Posts.Max(p => p.Id);
                id++;
            }

            post.Id = id;

            context.Posts.Add(post);
            context.SaveChanges();

            return Task.FromResult(post);
        }

        public Task<IEnumerable<Post>> GetAllAsync()
        {
            IEnumerable<Post> result = context.Posts.AsEnumerable();
            return Task.FromResult(result);
        }

        public Task<Post?> GetByIdAsync(int id)
        {
            Post? existing = context.Posts.FirstOrDefault(p => p.Id == id);

            return Task.FromResult(existing);
        }

        public Task<IEnumerable<Post>> GetByUserIdAsync(int id)
        {
            IEnumerable<Post> result = context.Posts.Where(p => p.Creator.Id == id);
            return Task.FromResult(result);
        }
    }
}
