//DTO de la entidad Clientes
using System;
using System.Collections.Generic;
using System.Text;
namespace Framework.Application.DTO
{
    public class ClientesDTO {
        public string  Identificacion { get; set; }
        public string  PrimerNombre { get; set; }
        public string  SegundoNombre { get; set; }
        public string  PrimerApellido { get; set; }
        public string  SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Clave { get; set; }
        public string Token { get; set; }
    } 
}