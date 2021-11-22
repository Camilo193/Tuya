using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GLoBUS.Framework.APIRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientesController : Controller
    {
        [HttpGet("{Nombre}/{Apellidos}")]
        public IActionResult GetSaludar(string Nombre, string Apellidos)
        {
            return Ok("Hola " + Nombre + " " + Apellidos);
        }

        [HttpPost]
        public IActionResult PostSaludar([FromBody] Saludos iSaludos)
        {
            return Ok(iSaludos);
        }
    }

    public class Saludos
    {
        public int Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
    }
}