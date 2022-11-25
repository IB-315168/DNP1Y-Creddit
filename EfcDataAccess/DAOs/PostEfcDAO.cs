using Application.DAOInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcDataAccess.DAOs
{
    public class PostEfcDAO : IPostDAO
    {
        private readonly UPCContext context;

        public PostEfcDAO(UPCContext context)
        {
            this.context = context;
        }

        public async Task<Post> CreateAsync(Post post)
        {
            EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
            return newPost.Entity;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            IQueryable<Post> posts = context.Posts.AsQueryable();
            return await posts.ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            Post? existing = await context.Posts.Include(post => post.Creator).SingleOrDefaultAsync(post => post.Id == id);
            return existing;
        }

        public async Task<IEnumerable<Post>> GetByUserIdAsync(int id)
        {
            IQueryable<Post> query = context.Posts.Include(post => post.Creator).AsQueryable();

            query = query.Where(post => id == post.Creator.Id);

            List<Post> result = await query.ToListAsync();

            return result;
        }
    }
}
