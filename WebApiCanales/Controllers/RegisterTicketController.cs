using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCanales.Clases;

namespace WebApiCanales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterTicketController : ControllerBase
    {
        // GET: api/RegisterTicket
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RegisterTicket/5
       
        // POST: api/RegisterTicket
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/RegisterTicket/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
