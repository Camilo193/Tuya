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
    public class ClientesController : ControllerBase
    {
        #region Inyección de dependencias
        private readonly IClientesApplication _clientesApplication;
        private readonly AppSettings _appSettings;


        public ClientesController(IClientesApplication clientesApplication, IOptions<AppSettings> appSettings)
        {
            _clientesApplication = clientesApplication;
            _appSettings = appSettings.Value;
        }
        #endregion

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Autenticar([FromBody] ClientesDTO clientesDTO)
        {
            var response = _clientesApplication.Autenticar(clientesDTO.Identificacion, clientesDTO.Clave);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                    return NotFound(response.Message);
            }

            return BadRequest(response.Message);
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] ClientesDTO clienteDto)
        {
            if (clienteDto == null)
                return BadRequest();

            var response = _clientesApplication.Insertar(clienteDto);
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
        public IActionResult Actualizar([FromBody] ClientesDTO clienteDto)
        {
            if (clienteDto == null)
                return BadRequest();

            var response = _clientesApplication.Actualizar(clienteDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            
            }
            else
            {
                return BadRequest(response.Message);      
            }
        }

        [HttpDelete("{Identificacion}")]
        public IActionResult Eliminar(string Identificacion)
        {
            var response = _clientesApplication.Eliminar(Identificacion);
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
            var response = _clientesApplication.ObtenerTodos();
            if (response.IsSuccess)
            {
                return Ok(response);
            
            }
            else
            {
                return BadRequest(response.Message);
            
            }
        }


        [HttpGet("{Identificacion}")]
        public IActionResult ObtenerPorIdentificacion(string Identificacion)
        {
            var response = _clientesApplication.ObtenerPorIdentificacion(Identificacion);
            if (response.IsSuccess)
            {
                return Ok(response);
            
            }
            else
            {
                return BadRequest(response.Message);
            
            }
        }

        private string BuildToken(Response<ClientesDTO> clientesDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, clientesDTO.Data.Identificacion)
                }),
                //Expires = DateTime.UtcNow.AddMinutes(1),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.IsSuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
