//Interfaz del dominio de la entidad Detalles
using Framework.Domain.Entity;
using System.Collections.Generic;


namespace Framework.Domain.Interface
{
    public interface IDetallesDomain {
        bool Insertar(Detalles[] Detalle);
        bool Actualizar(Detalles Detalle);
        bool Eliminar(int Codigo);
        IEnumerable<Detalles>ObtenerTodos();
        IEnumerable<Detalles>ObtenerPorCodigo(int Codigo);
    }
}