using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic userLogic;

        public UsersController(IUserLogic userLogic)
        {
            this.userLogic = userLogic;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] UserCreationDTO userToCreate)
        {
            try
            {
                User user = await userLogic.CreateAsync(userToCreate);
                return Created($"[controller]/{user.Id}", user);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                User user = await userLogic.GetByIdAsync(id);
                return Created($"[controller]/{user.Id}", user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
