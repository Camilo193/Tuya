//Interfaz de aplicacion de la entidad Facturas
using Framework.Application.DTO;
using Framework.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Application.Interface
{
    public interface IFacturasApplication
    {

        Response<bool> Insertar(FacturasDTO factura);
        Response<dynamic> RecibirPedido(List<PedidosDTO> detalle);
        Response<dynamic> EnviarPedido(List<PedidosDTO> detalle);
        Response<bool> Actualizar(FacturasDTO factura);
        Response<bool> Eliminar(int Codigo);
        Response<IEnumerable<FacturasDTO>> ObtenerTodos();
        Response<IEnumerable<FacturasDTO>> ObtenerPorCodigo(int Codigo);

        #region Métodos Asincronos
        //Response<Task<bool>> InsertarAsync(FacturasDTO factura);
        //Response<Task<IEnumerable<FacturasDTO>>> ObtenerTodosAsync();
        #endregion
    }
}
