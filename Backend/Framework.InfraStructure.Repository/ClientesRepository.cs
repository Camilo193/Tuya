//Repository Clientes
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Framework.Domain.Entity;
using Framework.InfraStructure.Interface;
using Framework.Transversal.Common;
using Framework.InfraStructure.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;

namespace Framework.InfraStructure.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly EFConnectionFactory _EFConnectionFactory;
        private readonly IConnectionFactory _connectionFactory;

        public ClientesRepository(IConnectionFactory connectionFactory, EFConnectionFactory EFConnectionFactory)
        {
            _EFConnectionFactory = EFConnectionFactory;
            _connectionFactory = connectionFactory;
        }


        public bool Eliminar(string Identificacion)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspEliminarClientes";

                var parameters = new DynamicParameters();
                parameters.Add("Identificacion", Identificacion);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result < 0;
            }
        }
        
        public IEnumerable<Clientes> ObtenerTodos()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                //var lst = connection.Database.
                var query = "UspObtenerClientes";

                var result = connection.Query<Clientes>(query, commandType: CommandType.StoredProcedure);
                return result;
            };

            using (var connection = _connectionFactory.GetConnection)
            {

                var query = "UspObtenerClientes";

                var result = connection.Query<Clientes>(query, commandType: CommandType.StoredProcedure);
                return result;
            };


        }

        public IEnumerable<Clientes> ObtenerPorIdentificacion(string Identificacion)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspObtenerClientesPorIdentificacion";
                
                var parameters = new DynamicParameters();
                
                parameters.Add("Identificacion", Identificacion);

                var result = connection.Query<Clientes>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            };
        }
        
                
        public bool Actualizar(Clientes Cliente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspActualizarClientes";

                var parameters = new DynamicParameters();
                
                parameters.Add("Identificacion", Cliente.Identificacion);
                parameters.Add("PrimerNombre", Cliente.PrimerNombre);
                parameters.Add("SegundoNombre", Cliente.SegundoNombre);
                parameters.Add("PrimerApellido", Cliente.PrimerApellido);
                parameters.Add("SegundoApellido", Cliente.SegundoApellido);
                parameters.Add("FechaNacimiento", Cliente.FechaNacimiento);
                
                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result < 0;
            }
        } 
        
        public bool Insertar(Clientes Cliente)
        {
            using (var context = _EFConnectionFactory)
            {
                Cliente.Clave = encriptar(Cliente.Clave);
                context.Clientes.Add(Cliente);
                return context.SaveChanges() > 0;

            }
        }

        public Clientes Autenticar(string Identificacion, string Clave)
        {
            using (var context = _EFConnectionFactory)
            {
                var result = context.Clientes.Where(x => x.Identificacion == Identificacion && x.Clave == encriptar(Clave)).FirstOrDefault();

                var stores = context.Clientes.Select(x => new { x.Identificacion, x.PrimerNombre, x.PrimerApellido, x.Clave }).Where(x => x.Identificacion == Identificacion && x.Clave == encriptar(Clave)).FirstOrDefault();
                
                return result;

            }
        }

        public string encriptar(string Clave)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(Clave));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}