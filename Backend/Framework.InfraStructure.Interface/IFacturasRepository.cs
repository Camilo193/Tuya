//IRepository Facturas

using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain.Entity;
using Framework.Application.DTO;

namespace Framework.InfraStructure.Interface
{
    public interface IFacturasRepository {

        bool Insertar(Facturas Factura);
        dynamic RecibirPedido(List<PedidosDTO> Pedido);
        dynamic EnviarPedido(List<PedidosDTO> Pedido);
        bool Actualizar(Facturas Factura);
        bool Eliminar(int Codigo);
        IEnumerable<Facturas>ObtenerTodos();
        IEnumerable<Facturas>ObtenerPorCodigo(int Codigo);

    }
}