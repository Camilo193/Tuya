//Interfaz de aplicacion de la entidad Clientes
using Framework.Application.DTO;
using Framework.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Application.Interface
{
    public interface IClientesApplication
    {
        Response<ClientesDTO> Autenticar (string Identificacion, string Clave);
        Response<bool> Insertar(ClientesDTO cliente);
        Response<bool> Actualizar(ClientesDTO cliente);
        Response<bool> Eliminar(string Identificacion);
        Response<IEnumerable<ClientesDTO>> ObtenerTodos();
        Response<IEnumerable<ClientesDTO>> ObtenerPorIdentificacion(string Identificacion);

        #region Métodos Asincronos
        //Response<Task<bool>> InsertAsync(ClientesDTO cliente);
        //Response<Task<IEnumerable<ClientesDTO>>> GetAllAsync();
        #endregion
    }
}
