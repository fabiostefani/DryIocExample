using System;
using System.Threading.Tasks;
using DryIoCExample.Entities;
using DryIoCExample.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DryIoCExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;        

        public UserController(ILogger<OrderController> logger)
        {            
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IUserRepository userRepository)
        {
            return Ok(await userRepository.GetAll());
        }

        [HttpGet]
        [Route("Get/{id:guid}")]
        public async Task<IActionResult> GetById([FromServices] IUserRepository userRepository, Guid id)
        {
            return Ok(await userRepository.GetById(id));
        }

        [HttpPost]        
        public async Task<IActionResult> Post([FromServices] IUserRepository userRepository, [FromBody] User user)
        {
            user.Id = Guid.NewGuid();
            await userRepository.Save(user);
            return Created(nameof(GetById), user.Id);
        }
    }
}
