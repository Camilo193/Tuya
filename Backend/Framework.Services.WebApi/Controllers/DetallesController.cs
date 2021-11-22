
using Framework.Application.DTO;
using Framework.Application.Interface;
using Framework.Services.WebApi.Helpers;
using Framework.Transversal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Framework.Services.WebApi.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetallesController : Controller
    {
        #region Inyección de dependencias
        private readonly IDetallesApplication _detallesApplication;

        private readonly AppSettings _appSettings;

        public DetallesController(IDetallesApplication detallesApplication, IOptions<AppSettings> appSettings)
        {
            _detallesApplication = detallesApplication;
            _appSettings = appSettings.Value;
        }
        #endregion

        [HttpPost]
        public IActionResult Insertar([FromBody]DetallesDTO[] detalleDto)
        {
            if (detalleDto == null)
                return BadRequest();

            var response = _detallesApplication.Insertar(detalleDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            
            }
            else
            {
                return BadRequest(response.Message);   
            }
        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] DetallesDTO detalleDto)
        {
            if (detalleDto == null)
                return BadRequest();

            var response = _detallesApplication.Actualizar(detalleDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            
            }
            else
            {
                return BadRequest(response.Message);      
            }
        }

        [HttpDelete("{Codigo}")]
        public IActionResult Eliminar(int Codigo)
        {
            var response = _detallesApplication.Eliminar(Codigo);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var response = _detallesApplication.ObtenerTodos();
            if (response.IsSuccess)
            {
                return Ok(response);
            
            }
            else
            {
                return BadRequest(response.Message);
            
            }
        }


        [HttpGet("{Codigo}")]
        public IActionResult ObtenerPorCodigo(int Codigo)
        {
            var response = _detallesApplication.ObtenerPorCodigo(Codigo);
            if (response.IsSuccess)
            {
                return Ok(response);
            
            }
            else
            {
                return BadRequest(response.Message);
            
            }
        }
    }
}
