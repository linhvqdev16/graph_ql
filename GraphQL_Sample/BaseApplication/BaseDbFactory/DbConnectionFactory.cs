using MySqlConnector;

namespace GraphQL_Sample.BaseApplication.BaseDbFactory;

public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(string connectionString)
    {
        _connectionString = connectionString; 
    }
    
    public async Task<T> WithConnection<T>(Func<MySqlConnection, Task<T>> function)
    {
        try
        {
            using var dbConnection = await GetNewConnectionAsync(_connectionString);
            return await function(dbConnection);
        }
        catch (TimeoutException ex)
        {
            ex.Data["Base Connection.Message - With Connection"] = "Timeout Exception";
            ex.Data["Base Connection.Message - With Connection"] = _connectionString;
            throw;
        }
        catch (MySqlException ex)
        {
            ex.Data["Base Connection.Message - With Connection"] = "Mysql Exception";
            ex.Data["Base Connection.Message - With Connection"] = _connectionString;
            throw;
        }
        catch (Exception ex)
        {
            ex.Data["Base Connection.Message - With Connection"] = "Execute Exception";
            ex.Data["Base Connection.Message - With Connection"] = _connectionString;
            throw;
        }
    }

    private async Task<MySqlConnection> GetNewConnectionAsync(string connectionString)
    {
        try
        {
            MySqlConnection connection = new MySqlConnection(connectionString: connectionString); 
            await connection.OpenAsync();
            return connection; 
        }
        catch (Exception ex)
        {
            ex.Data["Base Connection.Message - Create Connection"] = "Not new Mysql Connection";
            ex.Data["Base Connection.Message - Create Connection"] = connectionString;
            throw;
        }
    }
}   