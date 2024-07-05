using GraphQL_Sample.Models;
using GraphQL_Sample.PresentationLayer.InterfaceService;
using HotChocolate.Resolvers;

namespace GraphQL_Sample.GraphQL.GraphQLType;

public class DemoGroupType : ObjectType<GroupModel>
{
    protected override void Configure(IObjectTypeDescriptor<GroupModel> descriptor)
    {
        descriptor.Field(x => x.GroupdId).Type<IdType>();
        descriptor.Field(x => x.ShortName).Type<StringType>();
        descriptor.Field(x => x.Name).Type<StringType>();
        descriptor.Field<StudentResolver>(x => x.GetStudents(default, default));
    }
}

public class GroupResolver
{
    private readonly IGroupService _groupService;

    public GroupResolver([Service] IGroupService groupService)
    {
        _groupService = groupService; 
    }

    public GroupModel? GetGroup(StudentModel? model, IResolverContext? context)
    {
        return _groupService.GetAll().FirstOrDefault(x => model != null && x.GroupdId == model.GroupId);
    }
}