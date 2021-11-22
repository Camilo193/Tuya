using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Domain.Entity
{
    public class InformacionFacturas
    {

        public Facturas Factura { get; set; }

        public List<Detalles> Detalle { get; set; }
    }
}
