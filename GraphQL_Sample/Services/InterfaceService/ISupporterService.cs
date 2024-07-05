using GraphQL_Sample.Models.Entity;

namespace GraphQL_Sample.PresentationLayer.InterfaceService;

public interface ISupporterService
{
    Task<SupportEntity[]> GetAll();
    Task<SupportEntity?> CreateSupport(SupportEntity request);
    Task<SupportEntity?> UpdateSupport(SupportEntity request);
    Task<SupportEntity?> DeleteSupport(SupportEntity request);
}