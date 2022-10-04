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

        public PostsController(IPostLogic postLogic)
        {
            this.postLogic = postLogic;
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

        [HttpGet]
        public async Task<ActionResult<Post>> GetByIdAsync([FromQuery] int? id)
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
    }
}
