using GraphQL_Sample.Models;
using GraphQL_Sample.PresentationLayer.InterfaceService;
using HotChocolate.Resolvers;

namespace GraphQL_Sample.GraphQL.GraphQLType;

public class DemoStudentType : ObjectType<StudentModel>
{
    protected override void Configure(IObjectTypeDescriptor<StudentModel> descriptor)
    {
        descriptor.Field(x => x.StudentId).Type<IdType>();
        descriptor.Field(x => x.Name).Type<StringType>();
        descriptor.Field<GroupResolver>(x => x.GetGroup(default, default));
    }
}
            
public class StudentResolver
{
    private readonly IStudentService _studentService;

    public StudentResolver([Service] IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<IEnumerable<StudentModel?>> GetStudents(GroupModel? groupModel, IResolverContext? context)
    {
        return await _studentService.GetStudentByGroupId(context.Parent<GroupModel>().GroupdId ?? 0);
    }
}