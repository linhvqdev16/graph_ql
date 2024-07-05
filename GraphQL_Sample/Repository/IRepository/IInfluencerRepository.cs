using GraphQL_Sample.Models.Entity;

namespace GraphQL_Sample.Repository.IRepository;

public interface IInfluencerRepository
{
    Task<InfluencerEntity?> GetInfluencerById(int? influencerId);
    Task<InfluencerEntity?> CreateInfluencer(InfluencerEntity? request);
    Task<InfluencerEntity?> UpdateInfluencer(InfluencerEntity? request);
    Task<InfluencerEntity?> DeleteInfluencer(InfluencerEntity? request);
    Task<InfluencerEntity[]> GetAll();
}