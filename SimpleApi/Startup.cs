using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Prometheus;
using SimpleApi.Domain.DB.Configuration;
using SimpleApi.Infrastructure.Cqs.Impl;
using SimpleApi.Infrastructure.Cqs.Interfaces;
using SimpleApi.Infrastructure.PropertyInclusion;
using SimpleApi.Infrastructure.Repository;
using SimpleApi.Security;
using System;
using System.Linq;
using System.Reflection;
using System.Security.Claims;

namespace SimpleApi
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
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SimpleApi", Version = "v1" });
            });

            string connection = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<StorageContext>(options => options.UseNpgsql(connection));

            ConfigureGenericServices(services, typeof(IPropertyInclusion<>));
            services.AddScoped(typeof(IPropertyInclusion<>), typeof(DefaultPropertyInclusion<>));

            services.AddScoped<DbContext, StorageContext>();

            services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));

            services.AddScoped<ICommandHandlerManager, CommandHandlerManager>();

            services.AddScoped<IQueryHandlerManager, QueryHandlerManager>();

            var referencedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            var businessLogicAssemblies = referencedAssemblies
                .Where(a => a.Name.EndsWith(".Domain"))
                .Select(a => Assembly.Load(a))
                .ToArray();
            ConfigureGenericServices(services, typeof(ICommandHandler<,>), businessLogicAssemblies);
            ConfigureGenericServices(services, typeof(IQueryHandler<,>), businessLogicAssemblies);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = Configuration["Auth0:Authority"];
                options.Audience = Configuration["Auth0:Audience"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier
                };
                options.RequireHttpsMetadata = false;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:paid-subscriptions", policy =>
                    policy.Requirements.Add(new HasScopeRequirement("read:paid-subscriptions", Configuration["Auth0:Authority"])));
            });

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleApi v1");
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseHttpMetrics();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapMetrics();
            });
        }

        private void ConfigureGenericServices(IServiceCollection services, Type genericType, Assembly[] assemblies = null)
        {
            var assembliesWithImplementations = assemblies ?? new[] { genericType.Assembly };

            var implementations = assembliesWithImplementations.SelectMany(a => a.GetExportedTypes()
                .Where(t => t.IsClass && !t.IsGenericType
                    && t.GetInterfaces().Any(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == genericType
                    )
                )
            );

            foreach (var implementation in implementations)
            {
                var itemInterface = implementation.GetInterfaces().First();
                services.AddScoped(itemInterface, implementation);
            }
        }
    }
}