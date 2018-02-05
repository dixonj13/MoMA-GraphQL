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
        public RedisConfiguration RedisConfig { get; }

        public IConfiguration Configuration { get; }

        private IHostingEnvironment Environment { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            RedisConfig = Configuration.GetSection("Redis").Get<RedisConfiguration>();

            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton(RedisConfig);
            services.AddSingleton<ISerializer, ProtobufSerializer>();
            services.AddSingleton<ICacheClient, StackExchangeRedisCacheClient>();

            services.AddScoped<IDocumentExecuter, DocumentExecuter>();

            services.AddScoped<MoMAQuery>();
            services.AddTransient<IArtistRepository, ArtistCache>();
            services.AddTransient<IArtworkRepository, ArtworkCache>();

            services.AddTransient<ArtistType>();
            services.AddTransient<ArtworkType>();
            services.AddTransient<DimensionsType>();
            services.AddTransient<UnitLengthType>();

            var sp = services.BuildServiceProvider();

            services.AddScoped<ISchema>(_sp =>
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
                app.UseGraphiQl();
            }

            app.UseMvc();

            if (env.IsDevelopment())
            {
                cache.EnsureRedisSeed();
            }
        }
    }
}
