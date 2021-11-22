//Interfaz de aplicacion de la entidad Productos
using Framework.Application.DTO;
using Framework.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Application.Interface
{
    public interface IProductosApplication
    {
        
        Response<bool> Insertar(ProductosDTO producto);
        Response<bool> Actualizar(ProductosDTO producto);
        Response<bool> Eliminar(int Codigo);
        Response<IEnumerable<ProductosDTO>> ObtenerTodos();
        Response<IEnumerable<ProductosDTO>> ObtenerPorCodigo(int Codigo);

        #region Métodos Asincronos
        //Response<Task<bool>> InsertAsync(ProductosDTO producto);
        //Response<Task<IEnumerable<ProductosDTO>>> GetAllAsync();
        #endregion
    }
}
