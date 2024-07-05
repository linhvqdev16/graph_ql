using GraphQL_Sample.Models;
using GraphQL_Sample.Models.Entity;
using GraphQL_Sample.PresentationLayer.InterfaceService;

namespace GraphQL_Sample.GraphQL.GraphQLMutation;

public class GraphQLMutation
{
    private readonly IStudentService _studentService;
    private readonly IInfluencerService _influencerService;
    private readonly ISupporterService _supporterService;

    public GraphQLMutation(IStudentService studentService, IInfluencerService influencerService, ISupporterService supporterService)
    {
        _studentService = studentService;
        _influencerService = influencerService;
        _supporterService = supporterService; 
    }

    public async Task<StudentModel?> CreateStudent(StudentModel request)
    {
        return await _studentService.CreateStudent(request); 
    }

    public async Task<StudentModel?> DeleteStudent(StudentModel request)
    {
        return await _studentService.DeleteStudent(request);
    }

    public async Task<StudentModel?> UpdateStudent(StudentModel request)
    {
        return await _studentService.UpdateStudent(request);
    }

    public async Task<InfluencerEntity?> CreateInfluencer(InfluencerEntity? request)
    {
        return await _influencerService.CreateInfluencer(request); 
    }

    public async Task<InfluencerEntity?> UpdateInfluencer(InfluencerEntity? request)
    {
        return await _influencerService.UpdateInfluencer(request); 
    }

    public async Task<InfluencerEntity?> DeleteInfluencer(InfluencerEntity? request)
    {
        return await _influencerService.DeleteInfluencer(request); 
    }

    public async Task<SupportEntity?> CreateSupport(SupportEntity request)
    {
        return await _supporterService.CreateSupport(request: request); 
    }

    public async Task<SupportEntity?> UpdateSupport(SupportEntity request)
    {
        return await _supporterService.UpdateSupport(request: request);
    }

    public async Task<SupportEntity?> DeleteSupport(SupportEntity request)
    {
        return await _supporterService.DeleteSupport(request: request); 
    }
}