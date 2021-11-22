using System.Data;

namespace Framework.Transversal.Common
{
    public interface IConnectionFactory
    {

        IDbConnection GetConnection { get; }
    }
}
