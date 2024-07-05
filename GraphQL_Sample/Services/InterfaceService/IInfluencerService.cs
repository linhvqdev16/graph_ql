using GraphQL_Sample.Models.Entity;

namespace GraphQL_Sample.PresentationLayer.InterfaceService;

public interface IInfluencerService
{
    Task<InfluencerEntity?> GetInfluencerById(InfluencerEntity request);
    Task<InfluencerEntity[]> GetAll();
    Task<InfluencerEntity?> CreateInfluencer(InfluencerEntity? request);
    Task<InfluencerEntity?> UpdateInfluencer(InfluencerEntity? request);
    Task<InfluencerEntity?> DeleteInfluencer(InfluencerEntity? request);
}