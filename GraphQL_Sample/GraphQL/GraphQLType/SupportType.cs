using GraphQL_Sample.Models.Entity;
using GraphQL_Sample.PresentationLayer.InterfaceService;
using HotChocolate.Resolvers;

namespace GraphQL_Sample.GraphQL.GraphQLType;

public class SupportType : ObjectType<SupportEntity>
{
    protected override void Configure(IObjectTypeDescriptor<SupportEntity> descriptor)
    {
        descriptor.Field(x => x.Id).Type<IdType>();
        descriptor.Field(x => x.ScoinId).Type<IntType>();
        descriptor.Field(x => x.ScoinName).Type<StringType>();
        descriptor.Field(x => x.SupportDate).Type<DateTimeType>();
        descriptor.Field(x => x.Status).Type<IntType>();
        descriptor.Field<SupportResolver>(x => x.GetInfluencerEntity(default, default));

        //descriptor.Field("user")
        //    .Argument("username", a => a.Type<NonNullType<StringType>>())
        //    .Resolve(context =>
        //{
        //    var username = context.ArgumentValue<string>("username");
        //});
    }
}

public class SupportResolver
{
    private readonly IInfluencerService _influencerService;

    public SupportResolver([Service]IInfluencerService influencerService)
    {
        _influencerService = influencerService;
    }

    public async Task<InfluencerEntity?> GetInfluencerEntity(SupportEntity? model, IResolverContext context)
    {
        return await _influencerService.GetInfluencerById(new InfluencerEntity()
        {
            Id = context.Parent<SupportEntity>().InfluencerId
        }); 
    }
}