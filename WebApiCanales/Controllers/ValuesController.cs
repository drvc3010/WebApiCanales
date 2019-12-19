using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCanales.Clases;

namespace WebApiCanales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get( string option)
        {

            Constantes ct = new Constantes();
            string result_val = "";
            int result = ct.InsertDataSqlServer(option);
            if (result > 0)
            {
                result_val = "Gracias por tu participación.";
            } else
            {
                result_val = "Hubo un error al registrar tu opción.";
            }


            return result_val;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
          
            return (5 * id).ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
