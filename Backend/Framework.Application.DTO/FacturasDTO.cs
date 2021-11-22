//DTO de la entidad Facturas
using System;
using System.Collections.Generic;
using System.Text;
namespace Framework.Application.DTO
{
    public class FacturasDTO {
        public int?  Codigo { get; set; }
        public DateTime? Fecha { get; set; }
        public string  Descripcion { get; set; }
        public string  Cliente { get; set; }
    } 
}