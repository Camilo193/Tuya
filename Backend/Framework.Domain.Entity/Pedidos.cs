using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Domain.Entity
{
    public class Pedidos
    {
        public int Factura { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Fecha { get; set; }
        public List<Detalles> Detalles { get; set; }
    }
}
