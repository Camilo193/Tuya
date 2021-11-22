//Repository Detalles
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Framework.Domain.Entity;
using Framework.InfraStructure.Interface;
using Framework.Transversal.Common;

namespace Framework.InfraStructure.Repository
{
    public class DetallesRepository : IDetallesRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public DetallesRepository(IConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;


        public bool Eliminar(int Codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspEliminarDetalles";

                var parameters = new DynamicParameters();
                parameters.Add("Codigo", Codigo);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        
        public IEnumerable<Detalles> ObtenerTodos()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspObtenerDetalles";

                var result = connection.Query<Detalles>(query, commandType: CommandType.StoredProcedure);
                return result;
            };
        }

        public IEnumerable<Detalles> ObtenerPorCodigo(int Codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspObtenerDetallesPorCodigo";
                
                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Codigo);

                var result = connection.Query<Detalles>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            };
        }
        
                
        public bool Actualizar(Detalles Detalle)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspActualizarDetalles";

                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Detalle.Codigo);
                parameters.Add("Cantidad", Detalle.Cantidad);
                parameters.Add("Precio", Detalle.Precio);
                parameters.Add("Factura", Detalle.Factura);
                parameters.Add("Producto", Detalle.Producto);
                
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        } 
        
        public bool Insertar(Detalles Detalle)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspInsertarDetalles";

                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Detalle.Codigo);
                parameters.Add("Cantidad", Detalle.Cantidad);
                parameters.Add("Precio", Detalle.Precio);
                parameters.Add("Factura", Detalle.Factura);
                parameters.Add("Producto", Detalle.Producto);
                
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Insertar(Detalles[] Detalle)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspInsertarDetalles";

                var parameters = new DynamicParameters();

                var ListaDetalles = Detalle.AsList<Detalles>();

                foreach (var variable in ListaDetalles)
                {
                    parameters.Add("Cantidad", variable.Cantidad);
                    parameters.Add("Precio", variable.Precio);
                    parameters.Add("Factura", variable.Factura);
                    parameters.Add("Producto", variable.Producto);

                    var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                    if (result != 1) return false; 
                }
                return true;
            }
        }

        public bool verificarStock(Detalles[] Detalle)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspVerificarStock";

                var parameters = new DynamicParameters();

                var ListaDetalles = Detalle.AsList<Detalles>();

                foreach (var variable in ListaDetalles)
                {
                    parameters.Add("Producto", variable.Producto);
                    parameters.Add("Cantidad", variable.Cantidad);

                    var result = connection.QuerySingle<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    if (result == 0) return false;
                }
                return true;
            }
        }
    }
}
