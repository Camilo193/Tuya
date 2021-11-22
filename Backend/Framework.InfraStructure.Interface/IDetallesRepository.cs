//IRepository Detalles

using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain.Entity;

namespace Framework.InfraStructure.Interface
{
    public interface IDetallesRepository {

        bool Insertar(Detalles[] Detalle);
        bool Actualizar(Detalles Detalle);
        bool verificarStock(Detalles[] Detalle);
        bool Eliminar(int Codigo);
        IEnumerable<Detalles>ObtenerTodos();
        IEnumerable<Detalles>ObtenerPorCodigo(int Codigo);

    }
}