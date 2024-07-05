using System.Data;
using MySqlConnector;

namespace GraphQL_Sample.BaseApplication.BaseDbFactory;

public interface IDbConnectionFactory
{
   Task<T> WithConnection<T>(Func<MySqlConnection, Task<T>> function);
}