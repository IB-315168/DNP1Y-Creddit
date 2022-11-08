using Application.Logic;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentLogic commentLogic;

        public CommentController(ICommentLogic commentLogic)
        {
            this.commentLogic = commentLogic;
        }

        [HttpPost("{id:int}")]
        public async Task<ActionResult> CreateCommentAsync([FromBody] CommentCreationDTO commentToCreate, [FromRoute] int id)
        {
            try
            {
                Comment comment = await commentLogic.CreateAsync(commentToCreate, id);
                return Created($"[controller]/{id}/{comment.Id}", comment);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsAsync([FromRoute] int id)
        {
            try
            {
                IEnumerable<Comment> comments = await commentLogic.GetAllAsync(id);
                return Ok(comments);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
