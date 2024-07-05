using GraphQL_Sample.Models.Entity;
using GraphQL_Sample.PresentationLayer.InterfaceService;
using GraphQL_Sample.Repository.IRepository;

namespace GraphQL_Sample.PresentationLayer.ImplementService;

public class InfluencerServiceImpl : IInfluencerService
{
    private readonly IInfluencerRepository _influencerRepository;

    public InfluencerServiceImpl(IInfluencerRepository influencerRepository)
    {
        _influencerRepository = influencerRepository;
    }
    
    public async Task<InfluencerEntity?> GetInfluencerById(InfluencerEntity request)
    {
        return await _influencerRepository.GetInfluencerById(request.Id); 
    }

    public async  Task<InfluencerEntity[]> GetAll()
    {
        return await _influencerRepository.GetAll(); 
    }

    public async Task<InfluencerEntity?> CreateInfluencer(InfluencerEntity? request)
    {
        return await _influencerRepository.CreateInfluencer(request: request);
    }

    public async Task<InfluencerEntity?> UpdateInfluencer(InfluencerEntity? request)
    {
        return await _influencerRepository.UpdateInfluencer(request); 
    }

    public async Task<InfluencerEntity?> DeleteInfluencer(InfluencerEntity? request)
    {
        return await _influencerRepository.DeleteInfluencer(request); 
    }
}