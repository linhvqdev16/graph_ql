using GraphQL_Sample.Models.Entity;

namespace GraphQL_Sample.GraphQL.GraphQLType;

public class InfluencerType : ObjectType<InfluencerEntity>
{
    protected override void Configure(IObjectTypeDescriptor<InfluencerEntity> descriptor)
    {
        descriptor.Field(x => x.Id).Type<IdType>();
        descriptor.Field(x => x.ScoinId).Type<IntType>();
        descriptor.Field(x => x.ScoinName).Type<StringType>();
        descriptor.Field(x => x.Point).Type<FloatType>();
        descriptor.Field(x => x.GameId).Type<IntType>();
        descriptor.Field(x => x.ServerId).Type<IntType>();
        descriptor.Field(x => x.RoleId).Type<IntType>();
        descriptor.Field(x => x.RoleName).Type<StringType>();
        descriptor.Field(x => x.NickName).Type<StringType>();
        descriptor.Field(x => x.Sologan).Type<StringType>();
        descriptor.Field(x => x.ReferenceName).Type<StringType>();
        descriptor.Field(x => x.YoutubeChanel).Type<StringType>();
        descriptor.Field(x => x.LiveGChanel).Type<StringType>();
        descriptor.Field(x => x.TwitchChanel).Type<StringType>();
        descriptor.Field(x => x.CreateDate).Type<DateTimeType>();
        descriptor.Field(x => x.LastUpdate).Type<DateTimeType>();
        descriptor.Field(x => x.Status).Type<IntType>();
    }
}