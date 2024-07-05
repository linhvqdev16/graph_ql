using MySql.Data.MySqlClient;

namespace GraphQL_Sample.DatabaseContext;

public class DatabaseContext
{
    public string ConnectionString { get; set;  }

    public DatabaseContext(string connectionString)
    {
        ConnectionString = connectionString; 
    }

    private MySqlConnection GetConnection()
    {
        return new MySqlConnection(ConnectionString); 
    }
}