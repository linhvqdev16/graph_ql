using GraphQL_Sample.Models.Entity;
using GraphQL_Sample.PresentationLayer.InterfaceService;
using GraphQL_Sample.Repository.IRepository;

namespace GraphQL_Sample.PresentationLayer.ImplementService;

public class SupporterServiceImpl : ISupporterService
{
    private readonly ISupporterRepository _supporterRepository;

    public SupporterServiceImpl(ISupporterRepository supporterRepository)
    {
        _supporterRepository = supporterRepository; 
    }
    
    public async Task<SupportEntity[]> GetAll()
    {
        return await _supporterRepository.GetAll(); 
    }

    public async Task<SupportEntity?> CreateSupport(SupportEntity request)
    {
        return await _supporterRepository.CreateSupport(request: request);
    }

    public async Task<SupportEntity?> UpdateSupport(SupportEntity request)
    {
        return await _supporterRepository.UpdateSupport(request: request); 
    }

    public async Task<SupportEntity?> DeleteSupport(SupportEntity request)
    {
        return await _supporterRepository.DeleteSupport(request: request);
    }
}