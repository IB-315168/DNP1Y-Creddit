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
    public class CommentEfcDAO : ICommentDAO
    {
        private readonly UPCContext context;

        public CommentEfcDAO(UPCContext context)
        {
            this.context = context;
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            EntityEntry<Comment> commentCreated = await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
            return commentCreated.Entity;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync(int id)
        {
            IQueryable<Comment> query = context.Comments.Include(comment => comment.Post)
                .Include(comment => comment.Creator).AsQueryable();

            query = query.Where(comment => id == comment.Post.Id);

            List<Comment> result = await query.ToListAsync();

            return result;
        }
    }
}
