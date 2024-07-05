using GraphQL_Sample.GraphQL.GraphQLType;
using GraphQL_Sample.Models;
using GraphQL_Sample.Models.Entity;
using GraphQL_Sample.PresentationLayer.InterfaceService;

namespace GraphQL_Sample.GraphQL.GraphQLQuery;

public class GraphQLQuery
{
    private readonly IStudentService _studentService;
    private readonly IGroupService _groupService;
    private readonly IInfluencerService _influencerService;
    private readonly ISupporterService _supporterService;

    public GraphQLQuery(IStudentService studentService, IGroupService groupService, IInfluencerService influencerService, ISupporterService supporterService)
    {
        _studentService = studentService;
        _groupService = groupService;
        _influencerService = influencerService;
        _supporterService = supporterService;
    }

    [UsePaging(SchemaType = typeof(DemoGroupType))]
    [UseFiltering]
    public IQueryable<GroupModel> Groups => _groupService.GetAll();
    
    [UsePaging(SchemaType = typeof(DemoStudentType))]
    [UseFiltering]
    public Task<IQueryable<StudentModel>> Students => _studentService.GetAll(); 
    
    [UsePaging(SchemaType = typeof(InfluencerType))]
    [UseFiltering]
    public Task<InfluencerEntity[]> InfluencerEntities => _influencerService.GetAll();

    [UsePaging(SchemaType = typeof(SupportType))]
    [UseFiltering]
    public Task<SupportEntity[]> Supporters => _supporterService.GetAll();
}