using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VegeRest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegeRestAPI.Controllers
{
    [ApiController]
    [Route("Orders")]

    public class OrdersController : ControllerBase
    {
        OrderStorage orderStorage;
        public OrdersController(IOrderStorage _projectStorage)
        {
            orderStorage = (OrderStorage)_projectStorage;
        }

        //GET all action
        [HttpGet]
        public ActionResult<List<Order>> GetAll() => orderStorage.GetAll();

        [HttpGet("{orderNum}")]
        public ActionResult<Order> Get(string orderNum)
        {
            var project = orderStorage.Get(orderNum);

            if (project == null)
                return NotFound();

            return project;
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            orderStorage.Add(order);
            return CreatedAtAction(nameof(Create), new { orderNum = order.OrderNumber }, order);
        }

        [HttpPut("{orderNum}")]
        public IActionResult Update(string orderNum, Order order)
        {
            if (orderNum != order.OrderNumber)
                return BadRequest();

            var existingProject = orderStorage.Get(orderNum);
            if (existingProject is null)
                return NotFound();

            orderStorage.ReadyByNumber(orderNum);

            return NoContent();
        }

        [HttpDelete("{orderNum}")]
        public IActionResult Delete(string orderNum)
        {
            var project = orderStorage.Get(orderNum);

            if (project is null)
                return NotFound();

            orderStorage.RemoveByNumber(orderNum);

            return NoContent();
        }

    }
}
