using Application.LogicInterfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IPostLogic postLogic;

        public HomeController(IPostLogic postLogic)
        {
            this.postLogic = postLogic;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllAsync()
        {
            try
            {
                IEnumerable<Post> posts = await postLogic.GetAllAsync();
                return Ok(posts);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
