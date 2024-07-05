using GraphQL_Sample.BaseApplication.BaseDbFactory;
using GraphQL_Sample.GraphQL;
using GraphQL_Sample.GraphQL.GraphQLMutation;
using GraphQL_Sample.GraphQL.GraphQLQuery;
using GraphQL_Sample.GraphQL.GraphQLType;
using GraphQL_Sample.PresentationLayer.ImplementService;
using GraphQL_Sample.PresentationLayer.InterfaceService;
using GraphQL_Sample.Repository.IRepository;
using GraphQL_Sample.Repository.RepositoryImpl;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using MySql.Data.MySqlClient;
using MySqlConnector;

namespace GraphQL_Sample;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<KestrelServerOptions>(options =>
        {
            options.AllowSynchronousIO = true;
        });

        services.Configure<IISServerOptions>(options =>
        {
            options.AllowSynchronousIO = true;
        });

        var dbConnectionString = Configuration.GetConnectionString("DefaultConnection");

        services.AddMySqlDataSource(dbConnectionString);

        if (dbConnectionString.Length > 0)
        {
            services.AddTransient<IDbConnectionFactory>(p => new DbConnectionFactory(dbConnectionString));
        }

        services.AddTransient<IInfluencerRepository, InfluencerRepositoryImpl>();
        services.AddTransient<IInfluencerService, InfluencerServiceImpl>();

        services.AddTransient<ISupporterService, SupporterServiceImpl>();
        services.AddTransient<ISupporterRepository, SupporterRepositoryImpl>();

        services.AddSingleton<IGroupService, GroupServiceImpl>();
        services.AddSingleton<IStudentService, StudentServiceImpl>();

        services.AddGraphQL(x => SchemaBuilder.New()
            .AddServices(x)
            .AddType<DemoGroupType>()
            .AddType<DemoStudentType>()
            .AddType<InfluencerType>()
            .AddType<SupportType>()
            .AddQueryType<GraphQLQuery>()
            .AddMutationType<GraphQLMutation>()
            .Create());

        services.AddControllers();
        services.AddEndpointsApiExplorer();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UsePlayground();
        }
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("AspNetCore GraphQL Test");
            });
            endpoints.MapGraphQL("/api");
        });
    }
}