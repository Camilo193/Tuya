//Repository Productos
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
    public class ProductosRepository : IProductosRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ProductosRepository(IConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;


        public bool Eliminar(int Codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspEliminarProductos";

                var parameters = new DynamicParameters();
                parameters.Add("Codigo", Codigo);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        
        public IEnumerable<Productos> ObtenerTodos()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspObtenerProductos";

                var result = connection.Query<Productos>(query, commandType: CommandType.StoredProcedure);
                return result;
            };
        }

        public IEnumerable<Productos> ObtenerPorCodigo(int Codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspObtenerProductosPorCodigo";
                
                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Codigo);

                var result = connection.Query<Productos>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            };
        }
        
                
        public bool Actualizar(Productos Producto)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspActualizarProductos";

                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Producto.Codigo);
                parameters.Add("Nombre", Producto.Nombre);
                parameters.Add("Precio", Producto.Precio);
                parameters.Add("Stock", Producto.Stock);
                
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        } 
        
        public bool Insertar(Productos Producto)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspInsertarProductos";

                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Producto.Codigo);
                parameters.Add("Nombre", Producto.Nombre);
                parameters.Add("Precio", Producto.Precio);
                parameters.Add("Stock", Producto.Stock);
                
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        } 
            
    }
}