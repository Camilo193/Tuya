using Framework.Application.DTO;
using Framework.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Application.Interface
{
    public interface IInformacionFacturasApplication
    {
        Response<bool> Insertar(InformacionFacturasDTO informacionFacturas);
    }
}
