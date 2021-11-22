using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain.Entity;

namespace Framework.InfraStructure.Interface
{
    public interface IInformacionFacturasRepository
    {
        bool Insertar(InformacionFacturas informacionFacturas);
        //bool VerificarStock(InformacionFacturas informacionFacturas);
    }
}
