//Clase de dominio de la entidad Facturas 
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain.Entity;
using Framework.Domain.Interface;
using Framework.InfraStructure.Interface;
using Framework.Application.DTO;

namespace Framework.Domain.Core
{
    public class FacturasDomain : IFacturasDomain{

        private readonly IFacturasRepository _facturasRepository;

        public FacturasDomain(IFacturasRepository facturasRepository) => _facturasRepository = facturasRepository;

        public bool Insertar(Facturas factura)
        {
            return _facturasRepository.Insertar(factura);
        }

        public bool Actualizar(Facturas factura)
        {
            return _facturasRepository.Actualizar(factura);
        }

        public bool Eliminar(int Codigo)
        {
            return _facturasRepository.Eliminar(Codigo);
        }

        public IEnumerable<Facturas> ObtenerTodos()
        {
            return _facturasRepository.ObtenerTodos();
        }
        
        public IEnumerable<Facturas> ObtenerPorCodigo(int Codigo)
        {
            return _facturasRepository.ObtenerPorCodigo(Codigo);
        }

        public dynamic RecibirPedido(List<PedidosDTO> Pedido)
        {
            return _facturasRepository.RecibirPedido(Pedido);
        }

        public dynamic EnviarPedido(List<PedidosDTO> Pedido)
        {
            return _facturasRepository.EnviarPedido(Pedido);
        }
    }
}
