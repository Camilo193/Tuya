using System;
using System.Collections.Generic;
using System.Globalization;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;
using System.Text;


namespace Framework.Application.DTO
{
    public class InformacionFacturasDTO
    {
        
        public FacturasDTO Factura { get; set; }

        public List<DetallesDTO> Detalle { get; set; }
    }
}
