using GraphQL_Sample.Models.Entity;

namespace GraphQL_Sample.Repository.IRepository;

public interface ISupporterRepository
{
    Task<SupportEntity?> GetSupportById(int? supportId);
    Task<SupportEntity[]> GetAll();
    Task<SupportEntity?> CreateSupport(SupportEntity request);
    Task<SupportEntity?> UpdateSupport(SupportEntity request);
    Task<SupportEntity?> DeleteSupport(SupportEntity request);
}