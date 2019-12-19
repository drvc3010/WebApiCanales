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
    public class ATMController : ControllerBase
    {
       
        [HttpGet]
        public ActionResult<string> Get(string IdAtm)
        {
            Constantes ct = new Constantes();
            string result = ct.ticketDetail(IdAtm);
            return result;
        }

        [HttpGet("{IdAtm}")]
        public ActionResult<string> Get(int id)
        {

            return (5 * id).ToString();
        }

    }

}