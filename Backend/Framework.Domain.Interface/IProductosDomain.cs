//Interfaz del dominio de la entidad Productos
using Framework.Domain.Entity;
using System.Collections.Generic;


namespace Framework.Domain.Interface
{
    public interface IProductosDomain {
        bool Insertar(Productos Producto);
        bool Actualizar(Productos Producto);
        bool Eliminar(int Codigo);
        IEnumerable<Productos>ObtenerTodos();
        IEnumerable<Productos>ObtenerPorCodigo(int Codigo);
    }
}