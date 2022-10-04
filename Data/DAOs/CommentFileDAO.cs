using Application.DAOInterfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAOs
{
    public class CommentFileDAO : ICommentDAO
    {
        private readonly FileContext context;

        public CommentFileDAO(FileContext context)
        {
            this.context = context;
        }
        public Task<Comment> CreateAsync(Comment comment)
        {
            int id = 1;
            if (context.Comments.Any())
            {
                id = context.Comments.Max(c => c.Id);
                id++;
            }

            comment.Id = id;

            context.Comments.Add(comment);
            context.SaveChanges();

            return Task.FromResult(comment);
        }
    }
}
