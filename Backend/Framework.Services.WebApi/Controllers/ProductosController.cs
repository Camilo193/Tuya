
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
    public class ProductosController : Controller
    {
        #region Inyección de dependencias
        private readonly IProductosApplication _productosApplication;

        private readonly AppSettings _appSettings;

        public ProductosController(IProductosApplication productosApplication, IOptions<AppSettings> appSettings)
        {
            _productosApplication = productosApplication;
            _appSettings = appSettings.Value;
        }
        #endregion

        [HttpPost]
        public IActionResult Insertar([FromBody] ProductosDTO productoDto)
        {
            if (productoDto == null)
                return BadRequest();

            var response = _productosApplication.Insertar(productoDto);
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
        public IActionResult Actualizar([FromBody] ProductosDTO productoDto)
        {
            if (productoDto == null)
                return BadRequest();

            var response = _productosApplication.Actualizar(productoDto);
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
            var response = _productosApplication.Eliminar(Codigo);
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
            var response = _productosApplication.ObtenerTodos();
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
            var response = _productosApplication.ObtenerPorCodigo(Codigo);
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
