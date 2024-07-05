using GraphQL_Sample.BaseApplication.BaseDbFactory;
using GraphQL_Sample.Models.Entity;
using GraphQL_Sample.Repository.IRepository;
using MySqlConnector;

namespace GraphQL_Sample.Repository.RepositoryImpl;

public class InfluencerRepositoryImpl : IInfluencerRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public InfluencerRepositoryImpl(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory; 
    }
    
    public async Task<InfluencerEntity?> GetInfluencerById(int? influencerId)
    {
        return await _dbConnectionFactory.WithConnection<InfluencerEntity>(async connection =>
        {
            var command = new MySqlCommand("SELECT inf.Id, inf.ScoinId, inf.ScoinName, inf.Point, inf.GameId," +
                                           " inf.ServerId, inf.RoleId, inf.RoleName, inf.NickName, inf.Sologan, inf.ReferenceName, " +
                                           "\ninf.YoutubeChanel, inf.LiveGChanel, inf.TwitchChanel, inf.Status " +
                                           "FROM Influencer inf WHERE inf.Id = @Influrncer_Id;\t", connection: connection);

            command.Parameters.AddWithValue("@Influrncer_Id", influencerId); 
            
            var result = await command.ExecuteReaderAsync();
            var model = new InfluencerEntity(); 
            while(await result.ReadAsync())
            {
                model = new InfluencerEntity()
                {
                    Id = result.GetInt32(0), 
                    ScoinId = result.GetInt32(1), 
                    ScoinName = result.GetString(2), 
                    Point = result.GetFloat(3), 
                    GameId = result.GetInt32(4), 
                    ServerId = result.GetInt32(5), 
                    RoleId = result.GetInt32(6), 
                    RoleName = result.GetString(7), 
                    NickName = result.GetString(8),
                    Sologan = result.GetString(9),
                    ReferenceName = result.GetString(10),
                    YoutubeChanel = result.GetString(11),
                    LiveGChanel = result.GetString(12), 
                    TwitchChanel = result.GetString(13),
                    Status = result.GetInt32(14)
                }; 
            }
            return model; 
        }); 
    }

    public async Task<InfluencerEntity?> CreateInfluencer(InfluencerEntity? request)
    {
        if (request == null)
        {
            return null; 
        }
        return await _dbConnectionFactory.WithConnection<InfluencerEntity?>(async connection =>
        {
            var command = new MySqlCommand(
                "INSERT INTO `demo_sample`.`Influencer` (`ScoinId`, `ScoinName`, `Point`, `GameId`, `ServerId`, `RoleId`, `RoleName`," +
                        "\n`NickName`, `Sologan`, `ReferenceName`, `YoutubeChanel`, `LiveGChanel`, `TwitchChanel`, `CreateDate`, `LastUpdate`, `Status`) " +
                        "\nVALUES (@ScoindId, @ScoindName, @Point, @GameId, @ServerId, @RoleId, @RoleName, @NickName, @Sologan, @ReferenceName, @YoutubeChanel, " +
                        "@LiveGChanel, @TwitchChanel, @CreateDate, @LastUpdate, @Status);",
                connection: connection);

            command.Parameters.AddWithValue("@ScoindId", request.ScoinId);
            command.Parameters.AddWithValue("@ScoindName", request.ScoinName);
            command.Parameters.AddWithValue("@Point", request.Point);
            command.Parameters.AddWithValue("@GameId", request.GameId);
            command.Parameters.AddWithValue("@ServerId", request.ServerId);
            command.Parameters.AddWithValue("@RoleId", request.RoleId);
            command.Parameters.AddWithValue("@RoleName", request.RoleName);
            command.Parameters.AddWithValue("@NickName", request.NickName);
            command.Parameters.AddWithValue("@Sologan", request.Sologan);
            command.Parameters.AddWithValue("@ReferenceName", request.ReferenceName);
            command.Parameters.AddWithValue("@YoutubeChanel", request.YoutubeChanel);
            command.Parameters.AddWithValue("@LiveGChanel", request.LiveGChanel);
            command.Parameters.AddWithValue("@TwitchChanel", request.TwitchChanel);
            command.Parameters.AddWithValue("@CreateDate", request.CreateDate);
            command.Parameters.AddWithValue("@LastUpdate", request.LastUpdate);
            command.Parameters.AddWithValue("@Status", request.Status);

            var result = await command.ExecuteNonQueryAsync();
            if (result > 0)
            {
                return request; 
            }

            return null;
        }); 
    }

    public async Task<InfluencerEntity?> UpdateInfluencer(InfluencerEntity? request)
    {
        if (request == null || request.Id == null)
        {
            return null; 
        }
        
        return await _dbConnectionFactory.WithConnection<InfluencerEntity?>(async connection =>
        {
            var command = new MySqlCommand(
                "UPDATE `demo_sample`.`Influencer` as tbInfluencer SET tbInfluencer.NickName = @NickName, " +
                "\ntbInfluencer.Sologan =  @Sologan, \ntbInfluencer.ReferenceName = @ReferenceName, " +
                "\ntbInfluencer.YoutubeChanel = @YoutubeChanel,\ntbInfluencer.LiveGChanel = @LiveGChanel, " +
                "\ntbInfluencer.TwitchChanel = @TwitchChanel, \ntbInfluencer.Status = @Status," +
                "\ntbInfluencer.LastUpdate = @LastUpdate\nWHERE tbInfluencer.Id = @Id; ",
                connection); 
            
            command.Parameters.AddWithValue("@NickName", request.NickName);
            command.Parameters.AddWithValue("@Sologan", request.Sologan);
            command.Parameters.AddWithValue("@ReferenceName", request.ReferenceName);
            command.Parameters.AddWithValue("@YoutubeChanel", request.YoutubeChanel);
            command.Parameters.AddWithValue("@LiveGChanel", request.LiveGChanel);
            command.Parameters.AddWithValue("@TwitchChanel", request.TwitchChanel);
            command.Parameters.AddWithValue("@LastUpdate", request.LastUpdate);
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

    public async Task<InfluencerEntity?> DeleteInfluencer(InfluencerEntity? request)
    {
        if (request == null || request.Id == null)
        {
            return null; 
        }

        return await _dbConnectionFactory.WithConnection<InfluencerEntity?>(async connection =>
        {
            var command =
                new MySqlCommand("DELETE FROM `demo_sample`.`Influencer` as tbInfluencer WHERE tbInfluencer.Id = @Id;", connection: connection);
            
            command.Parameters.AddWithValue("@Id", request.Id);
            var result = await command.ExecuteNonQueryAsync();
            if (result > 0)
            {
                return request; 
            }
            return null; 
        }); 
    }

    public async Task<InfluencerEntity[]> GetAll()
    {
        return await _dbConnectionFactory.WithConnection<InfluencerEntity[]>(async connection =>
        {
            var command = new MySqlCommand("SELECT inf.Id, inf.ScoinId, inf.ScoinName, inf.Point, inf.GameId," +
                                           " inf.ServerId, inf.RoleId, inf.RoleName, inf.NickName, inf.Sologan, inf.ReferenceName, " +
                                           "\ninf.YoutubeChanel, inf.LiveGChanel, inf.TwitchChanel, inf.Status " +
                                           "FROM Influencer inf\t", connection: connection);

            var result = await command.ExecuteReaderAsync();
            List<InfluencerEntity> influencerEntities = new List<InfluencerEntity>(); 
            while(await result.ReadAsync())
            {
                influencerEntities.Add(new InfluencerEntity()
                {
                    Id = result.GetInt32(0), 
                    ScoinId = result.GetInt32(1), 
                    ScoinName = result.GetString(2), 
                    Point = result.GetFloat(3), 
                    GameId = result.GetInt32(4), 
                    ServerId = result.GetInt32(5), 
                    RoleId = result.GetInt32(6), 
                    RoleName = result.GetString(7), 
                    NickName = result.GetString(8),
                    Sologan = result.GetString(9),
                    ReferenceName = result.GetString(10),
                    YoutubeChanel = result.GetString(11),
                    LiveGChanel = result.GetString(12), 
                    TwitchChanel = result.GetString(13),
                    Status = result.GetInt32(14)
                });
            }
            return influencerEntities.ToArray(); 
        }); 
    }
}