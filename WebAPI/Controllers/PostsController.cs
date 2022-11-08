using Application.Logic;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostLogic postLogic;
        private readonly ICommentLogic commentLogic;

        public PostsController(IPostLogic postLogic, ICommentLogic commentLogic)
        {
            this.postLogic = postLogic;
            this.commentLogic = commentLogic;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] PostCreationDTO postToCreate)
        {
            try
            {
                Post post = await postLogic.CreateAsync(postToCreate);
                return Created($"[controller]/{post.Id}", post);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("/api/[controller]/user")]
        public async Task<ActionResult<IEnumerable<Post>>> GetByUserIdAsync([FromQuery] int id)
        {
            try
            {
                IEnumerable<Post> posts = await postLogic.GetByUserIdAsync(id);
                return Ok(posts);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Post>> GetByIdAsync([FromRoute] int? id)
        {
            try
            {
                Post? post = await postLogic.GetByIdAsync(id);
                return Ok(post);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllAsync()
        {
            try
            {
                IEnumerable<Post> posts = await postLogic.GetAllAsync();
                return Ok(posts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
