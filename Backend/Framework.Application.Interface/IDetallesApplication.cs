//Interfaz de aplicacion de la entidad Detalles
using Framework.Application.DTO;
using Framework.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Application.Interface
{
    public interface IDetallesApplication
    {
        
        Response<bool> Insertar(DetallesDTO[] detalle);
        Response<bool> Actualizar(DetallesDTO detalle);
        Response<bool> Eliminar(int Codigo);
        Response<IEnumerable<DetallesDTO>> ObtenerTodos();
        Response<IEnumerable<DetallesDTO>> ObtenerPorCodigo(int Codigo);
        

        #region Métodos Asincronos
        //Response<Task<bool>> InsertAsync(DetallesDTO detalle);
        //Response<Task<IEnumerable<DetallesDTO>>> GetAllAsync();
        #endregion
    }
}
