using GraphQL_Sample.BaseApplication.BaseDbFactory;
using GraphQL_Sample.Models.Entity;
using GraphQL_Sample.Repository.IRepository;
using MySqlConnector;

namespace GraphQL_Sample.Repository.RepositoryImpl;

public class SupporterRepositoryImpl : ISupporterRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public SupporterRepositoryImpl(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
    
    public async Task<SupportEntity?> GetSupportById(int? supportId)
    {
        return await _dbConnectionFactory.WithConnection<SupportEntity?>(async connection =>
        {
            var command =
                new MySqlCommand(
                    "SELECT sp.Id, sp.ScoindId, sp.ScoinName, sp.InfuencerId, sp.SupportDate, sp.Status FROM Supporter AS sp WHERE sp.Id = @Id;",
                    connection);
            command.Parameters.AddWithValue("@Id", supportId); 
            var result = await command.ExecuteReaderAsync();
            while (await result.ReadAsync())
            {
                return new SupportEntity()
                {
                    Id = Int32.Parse(result.GetValue(0).ToString() ?? "0"),
                    ScoinId = Int32.Parse(result.GetValue(1).ToString() ?? "0"),
                    ScoinName = result.GetValue(2).ToString(),
                    InfluencerId = Int32.Parse(result.GetValue(3).ToString() ?? "0"),
                    // SupportDate = DateTime.ParseExact(result.GetValue(5).ToString()); 
                    Status = Int32.Parse(result.GetValue(5).ToString() ?? "0")
                };
            }
            return null; 
        }); 
    }

    public async Task<SupportEntity[]> GetAll()
    {
        return await _dbConnectionFactory.WithConnection<SupportEntity[]>(async connection =>
        {
            var command =
                new MySqlCommand(
                    "SELECT sp.Id, sp.ScoindId, sp.ScoinName, sp.InfuencerId, sp.SupportDate, sp.Status FROM Supporter AS sp;",
                    connection);
            var result = await command.ExecuteReaderAsync();
            var supporterList = new List<SupportEntity>(); 
            while (await result.ReadAsync())
            {
                supporterList.Add(new SupportEntity()
                {
                    Id = Int32.Parse(result.GetValue(0).ToString() ?? "0"), 
                    ScoinId = Int32.Parse(result.GetValue(1).ToString() ?? "0"), 
                    ScoinName = result.GetValue(2).ToString(), 
                    InfluencerId = Int32.Parse(result.GetValue(3).ToString() ?? "0"), 
                    // SupportDate = DateTime.ParseExact(result.GetValue(5).ToString()); 
                    Status = Int32.Parse(result.GetValue(5).ToString() ?? "0")
                });
            }
            return supporterList.ToArray(); 
        }); 
    }

    public async Task<SupportEntity?> CreateSupport(SupportEntity request)
    {
        return await _dbConnectionFactory.WithConnection<SupportEntity?>(async connection =>
        {
            var command = new MySqlCommand(
                "INSERT INTO `demo_sample`.`Supporter` (`ScoindId`, `ScoinName`, `InfuencerId`, `SupportDate`, `Status`) " +
                "\nVALUES (@ScoindId, @ScoinName, @InfuencerId, @SupportDate, @Status);\n", connection: connection);

            command.Parameters.AddWithValue("@ScoindId", request.ScoinId);
            command.Parameters.AddWithValue("@ScoinName", request.ScoinName);
            command.Parameters.AddWithValue("@InfuencerId", request.InfluencerId);
            command.Parameters.AddWithValue("@SupportDate", request.SupportDate);
            command.Parameters.AddWithValue("@Status", request.Status);

            var result = await command.ExecuteNonQueryAsync();
            if (result > 0)
            {
                return request;
            }
            return null; 
        }); 
    }

    public async Task<SupportEntity?> UpdateSupport(SupportEntity request)
    {
        return await _dbConnectionFactory.WithConnection<SupportEntity?>(async connection =>
        {
            var command = new MySqlCommand(
                "UPDATE `demo_sample`.`Supporter` AS sp SET sp.ScoindId = @ScoindId, sp.ScoinName = @ScoinName, " +
                "\nsp.InfuencerId = @InfuencerId, sp.SupportDate = @SupportDate, sp.Status = @Status WHERE sp.Id = @Id", connection: connection);

            command.Parameters.AddWithValue("@ScoindId", request.ScoinId);
            command.Parameters.AddWithValue("@ScoinName", request.ScoinName);
            command.Parameters.AddWithValue("@InfuencerId", request.InfluencerId);
            command.Parameters.AddWithValue("@SupportDate", request.SupportDate);
            command.Parameters.AddWithValue("@Status", request.Status);
            command.Parameters.AddWithValue("@Id", request.Id); 
            
            var result = await command.ExecuteNonQueryAsync();
            if (result > 0)
            {
                return request;
            }
            return null; 
        }); 
    }

    public async  Task<SupportEntity?> DeleteSupport(SupportEntity request)
    {
        return await _dbConnectionFactory.WithConnection<SupportEntity?>(async connection =>
        {
            var command = new MySqlCommand(
                "DELETE FROM `demo_sample`.`Supporter` AS sp WHERE sp.Id = @Id", connection: connection);
            
            command.Parameters.AddWithValue("@Id", request.Id);
            var result = await command.ExecuteNonQueryAsync();
            if (result > 0)
            {
                return request;
            }
            return null; 
        }); 
    }
}