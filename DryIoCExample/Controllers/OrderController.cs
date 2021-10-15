using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DryIoCExample.Entities;
using DryIoCExample.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DryIoCExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _orderRepository;

        public OrderController(ILogger<OrderController> logger,
                               IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _orderRepository.GetAll());
        }

        [HttpGet]
        [Route("Get/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _orderRepository.GetById(id));
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            order.Id = Guid.NewGuid();
            await _orderRepository.Save(order);
            return Created(nameof(GetById), order.Id);
        }
    }
}
