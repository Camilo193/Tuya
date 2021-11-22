//Entidad Facturas
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Framework.Domain.Entity
{
    
    public class Facturas {
        [Key]
        public int Codigo { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Cliente { get; set; }
    }
}