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
    public class ticketController : ControllerBase
    {
        // GET: api/ticket
        [HttpGet]
        public string  Get(string  idATM)
        {
            Constantes ct = new Constantes();
            string result = ct.ticketDetail(idATM);
            return result;
        }

        // GET: api/ticket/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ticket
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ticket/5
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
