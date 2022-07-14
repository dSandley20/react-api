using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using react_api.RepositoryInterfaces;
using react_api.Repositories;
using react_api.Entities;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace react_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Configuration Reader
        public IConfiguration Configuration { get; set; }

        //Cors
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        //Service Registration
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

          
            //tells the application how to treat DateTimeOffSet and Guids
            BsonSerializer.RegisterSerializer(new GuidSerializer(MongoDB.Bson.BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(MongoDB.Bson.BsonType.String));

            //configures the MongoDB Client so all we have to do is pass the collection name to the repository
            services.AddSingleton<IMongoDatabase>(ServiceProvider =>
            {
                var settings = Configuration.GetSection(nameof(DbConnectionConfig)).Get<DbConnectionConfig>();
                return new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            });

            //registering all of the controllers for the API
            services.AddSingleton<IBlogsRepository, MongoBlogsRepository>();
            services.AddSingleton<IJobsRepository, MongoJobsRepository>();
            services.AddSingleton<IRefrencesRepository, MongoReferencesRepository>();
            services.AddSingleton<IProjectsRepository, MongoProjectsRepository>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000",
                                            "https://localhost:3000");
                    });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "react_api", Version = "v1" });
            });
            //add service for connection to the appsettings.json file
            services.Configure<DbConnectionConfig>(Configuration.GetSection("DbConnection"));
        }

        //Request handing pipeline config , middleware
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "react_api v1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
