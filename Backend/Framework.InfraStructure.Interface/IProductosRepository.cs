//IRepository Productos

using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain.Entity;

namespace Framework.InfraStructure.Interface
{
    public interface IProductosRepository {

        bool Insertar(Productos Producto);
        bool Actualizar(Productos Producto);
        bool Eliminar(int Codigo);
        IEnumerable<Productos>ObtenerTodos();
        IEnumerable<Productos>ObtenerPorCodigo(int Codigo);

    }
}