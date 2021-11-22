using Framework.Domain.Entity;
using Framework.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Domain.Interface
{
    public interface IFacturasDomain {
        bool Insertar(Facturas Factura);
        dynamic RecibirPedido(List<PedidosDTO> detalles);
        dynamic EnviarPedido(List<PedidosDTO> detalles);
        bool Actualizar(Facturas Factura);
        bool Eliminar(int Codigo);
        IEnumerable<Facturas>ObtenerTodos();
        IEnumerable<Facturas>ObtenerPorCodigo(int Codigo);
    }
}