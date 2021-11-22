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
    public class InformacionFacturasController : Controller
    {
        #region Inyección de dependencias
        private readonly IInformacionFacturasApplication _informacionFacturasApplication;

        private readonly AppSettings _appSettings;

        public InformacionFacturasController(IInformacionFacturasApplication informacionFacturasApplication, IOptions<AppSettings> appSettings)
        {
            _informacionFacturasApplication = informacionFacturasApplication;
            _appSettings = appSettings.Value;
        }
        #endregion

        [HttpPost]
        public IActionResult Insertar([FromBody] InformacionFacturasDTO informacionFacturas)
        {
           if (informacionFacturas == null)
                return BadRequest();

            var response = _informacionFacturasApplication.Insertar(informacionFacturas);
            if (response.IsSuccess)
            {
                return Ok(response);

            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        //[HttpPut]
        //public IActionResult Actualizar([FromBody] FacturasDTO facturaDto)
        //{
        //    if (facturaDto == null)
        //        return BadRequest();

        //    var response = _facturasApplication.Actualizar(facturaDto);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);

        //    }
        //    else
        //    {
        //        return BadRequest(response.Message);
        //    }
        //}

        //[HttpDelete("{Codigo}")]
        //public IActionResult Eliminar(int Codigo)
        //{
        //    var response = _facturasApplication.Eliminar(Codigo);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }
        //    else
        //    {
        //        return BadRequest(response.Message);
        //    }
        //}


        //[HttpGet]
        //public IActionResult ObtenerTodos()
        //{
        //    var response = _facturasApplication.ObtenerTodos();
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);

        //    }
        //    else
        //    {
        //        return BadRequest(response.Message);

        //    }
        //}


        //[HttpGet("{Codigo}")]
        //public IActionResult ObtenerPorCodigo(int Codigo)
        //{
        //    var response = _facturasApplication.ObtenerPorCodigo(Codigo);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);

        //    }
        //    else
        //    {
        //        return BadRequest(response.Message);

        //    }
        //}
    }
}
