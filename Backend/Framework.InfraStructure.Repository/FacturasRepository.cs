//Repository Facturas
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Framework.Domain.Entity;
using Framework.InfraStructure.Interface;
using Framework.Transversal.Common;
using Framework.InfraStructure.Data;
using Framework.Application.DTO;


namespace Framework.InfraStructure.Repository
{
    public class FacturasRepository : IFacturasRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly EFConnectionFactory _EFConnectionFactory;

        public FacturasRepository(IConnectionFactory connectionFactory, EFConnectionFactory EFConnectionFactory) 
        { 
            _connectionFactory = connectionFactory;
            _EFConnectionFactory = EFConnectionFactory;
        }


        public bool Eliminar(int Codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspEliminarFacturas";

                var parameters = new DynamicParameters();
                parameters.Add("Codigo", Codigo);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        
        public IEnumerable<Facturas> ObtenerTodos()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspObtenerFacturas";

                var result = connection.Query<Facturas>(query, commandType: CommandType.StoredProcedure);
                return result;
            };
        }

        public IEnumerable<Facturas> ObtenerPorCodigo(int Codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspObtenerFacturasPorCodigo";
                
                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Codigo);

                var result = connection.Query<Facturas>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            };
        }
        
                
        public bool Actualizar(Facturas Factura)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspActualizarFacturas";

                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Factura.Codigo);
                parameters.Add("Fecha", Factura.Fecha);
                parameters.Add("Descripcion", Factura.Descripcion);
                parameters.Add("Cliente", Factura.Cliente);
                
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        } 
        
        public bool Insertar(Facturas Factura)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspInsertarFacturas";

                var parameters = new DynamicParameters();
                parameters.Add("Codigo", Factura.Codigo);
                parameters.Add("Fecha", Factura.Fecha.HasValue ? Factura.Fecha : Factura.Fecha = DateTime.Now);
                parameters.Add("Descripcion", Factura.Descripcion);
                parameters.Add("Cliente", Factura.Cliente);
                
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public dynamic RecibirPedido(List<PedidosDTO> Pedidos)
        {
            using (var context = _EFConnectionFactory)
            {
                var valorFacturas = new List<KeyValuePair<int, decimal>>();

                foreach (var factura in Pedidos) 
                {
                    var detallesFactura = context.Detalles.Where(x => x.Factura == factura.Factura).ToList();

                    decimal totalFactura = 0;

                    foreach (var detalle in detallesFactura)
                    {
                        //Se obtiene el valor total de la factura
                        totalFactura += detalle.Cantidad * detalle.Precio;
                    }
                    //Guardamos el valor de la factura
                    valorFacturas.Add(new KeyValuePair<int, decimal>(factura.Factura, totalFactura));
                }

                return valorFacturas;
            }
        }

        public dynamic EnviarPedido(List<PedidosDTO> Pedidos)
        {
            using (var context = _EFConnectionFactory)
            {
                var pedidos = new List<dynamic>();

                foreach (var factura in Pedidos)
                {
                    var detallesFactura = context.Detalles.Where(x => x.Factura == factura.Factura).ToList();

                    decimal totalFactura = 0;

                    foreach (var detalle in detallesFactura)
                    {
                        //Se obtiene el valor total de la factura
                        totalFactura += detalle.Cantidad * detalle.Precio;
                    }

                    var pedido = new Pedidos() 
                    {
                        Factura = factura.Factura,
                        ValorTotal = totalFactura,
                        Fecha = System.DateTime.UtcNow,
                        Detalles = detallesFactura
                    };

                    pedidos.Add(pedido);
                }
                
                return pedidos;
            }
        }
    }
}