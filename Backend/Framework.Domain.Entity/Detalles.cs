//Entidad Detalles
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Framework.Domain.Entity
{
    
    public class Detalles {
        [Key]
        public int Codigo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int Factura { get; set; }
        public int Producto { get; set; }
    }
}