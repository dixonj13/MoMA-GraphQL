using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoMAGraphQL.Data.Redis.Repositories;
using MoMAGraphQL.Data.Repositories;
using MoMAGraphQL.Data.Seed;
using MoMAGraphQL.GraphQL;
using MoMAGraphQL.GraphQL.Types;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Protobuf;

namespace MoMAGraphQL
{
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
            services.AddMvc();

            services.AddSingleton<ICacheClient>(new StackExchangeRedisCacheClient(
                new ProtobufSerializer(),
                new RedisConfiguration()
                {
                    AbortOnConnectFail = true,
                    ConnectTimeout = 3000,
                    Hosts = new RedisHost[]
                    {
                        new RedisHost() { Host = "localhost", Port = 6379 }
                    }
                }));

            services.AddScoped<MoMAQuery>();
            services.AddTransient<IArtistRepository, ArtistRepository>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<ArtistType>();

            var sp = services.BuildServiceProvider();

            services.AddScoped<ISchema>(_ =>
                new MoMASchema(type => (GraphType)sp.GetService(type))
                {
                    Query = sp.GetService<MoMAQuery>()
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ICacheClient cache)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            cache.EnsureRedisSeed();
        }
    }
}
