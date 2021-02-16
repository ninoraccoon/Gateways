using Aplication;
using Aplication.Contracts;
using Aplication.Dto;
using Gateways.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Gateways.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IGatewayService _gwservice;

        public GatewayController(IGatewayService gwservice)
        {
            _gwservice = gwservice;
        }
        // GET: api/<GatewayController>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Gateway>))]
        [ProducesResponseType(500)]
        public async Task<ICollection<Gateway>> Get()
        {
            return await _gwservice.GetAll();

        }

        // GET api/<GatewayController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Gateway))]
        [ProducesResponseType(500)]
        public async Task<Gateway> Get(int id)
        {
            return await _gwservice.Get(id);
        }

        // POST api/<GatewayController>
        [HttpPost]
        [ValidateModel]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(500)]
        public async Task<ActionResult<int>> Post([FromBody] Gateway value)
        {
           
            return new OkObjectResult(await _gwservice.Create(value));
        }

        // PUT api/<GatewayController>/5
        [HttpPut("{id}")]
        [ValidateModel]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(500)]
        public async Task<int> Put(int id, [FromBody] Gateway value)
        {
            return await _gwservice.Update(id, value);
        }

        // DELETE api/<GatewayController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(500)]
        public async Task<int> Delete(int id)
        {
            return await _gwservice.Remove(id);
        }
    }
}
