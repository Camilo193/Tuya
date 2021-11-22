using System.Data;
using System.Data.SqlClient;
using Framework.Transversal.Common;
using Microsoft.Extensions.Configuration;


namespace Framework.InfraStructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuracion)
        {
            _configuration = configuracion;
        }

        public IDbConnection GetConnection
        {
            get
            {
                SqlConnection conexion = new SqlConnection();
                if (conexion == null) return null;

                conexion.ConnectionString = _configuration.GetConnectionString("TuyaSQLServer");
                conexion.Open();
                return conexion;
            }
        }

    }
}
