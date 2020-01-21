using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApiCanales.Clases;

namespace WebApiCanales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ticketController : ControllerBase
    {
    
        // GET: api/ticket
        [HttpGet]
        public JObject Get(string  idATM)
        {
            Constantes ct = new Constantes();
            ConsultaTicket result = ct.ticketDetail(idATM);
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            JObject json = JObject.Parse(jsonString);
            return json;


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
