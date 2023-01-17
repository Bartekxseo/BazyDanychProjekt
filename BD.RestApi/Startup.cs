using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BD.DataAccess;
using BD.DataAccess.DbContextEvents;
using BD.DataAccess.DbContextEvents.Handlers;
using BD.Domain.FileStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Unity;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNet.OData.Extensions;
using AutoMapper;
using Microsoft.Extensions.FileProviders;
using BD.Services.House;
using BD.Services.Meter;
using BD.Services.DbHelper;

namespace BD.RestApi
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            //Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; }

        public void ConfigureContainer(IUnityContainer unityContainer)
        {

            DbContextEventDispatcher dbContextEventDispatcher = new DbContextEventDispatcher();
            unityContainer.RegisterInstance<IDbContextEventDispatcher>(dbContextEventDispatcher);
            unityContainer.RegisterType<EntityHistoryDbContextEventHandler, EntityHistoryDbContextEventHandler>();
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps("BD.Services");
            });
            unityContainer.RegisterInstance<IMapper>(mapperConfiguration.CreateMapper());
            unityContainer.RegisterInstance<AutoMapper.IConfigurationProvider>(mapperConfiguration);
            dbContextEventDispatcher.RegisterStep(() =>
            {
                var db = unityContainer.Resolve<EntityHistoryDbContextEventHandler>();
                return db;
            }
            );

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();
            services.AddScoped<BDDbContext>(x =>
            {
                return new BDDbContext(Configuration.GetConnectionString("BDDb"));
            });
            services.AddTransient<DbContext>(x =>
            {
                return x.GetService<BDDbContext>();
            });
            services.AddScoped<BDRead1DbContext>(x =>
            {
                return new BDRead1DbContext(Configuration.GetConnectionString("BDRead1Db"));
            });
            services.AddTransient<DbContext>(x =>
            {
                return x.GetService<BDRead1DbContext>();
            });
            services.AddScoped<BDRead2DbContext>(x =>
            {
                return new BDRead2DbContext(Configuration.GetConnectionString("BDDb"));
            });
            services.AddTransient<DbContext>(x =>
            {
                return x.GetService<BDRead2DbContext>();
            });
            services.AddMemoryCache();

            services.AddScoped<IHouseService, HouseService>();
            services.AddScoped<IMeterService, MeterService>();
            services.AddScoped<IDbHelper, DbHelper>();

            services.AddCors(builder => builder.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            ));

            services.AddSwaggerGen(swaggerAction =>
            {
                swaggerAction.SwaggerDoc("BDRestApi", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "BD Rest API",
                    Version = "1",
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swaggerAction.IncludeXmlComments(xmlPath);
            });

            services.AddOData();

            services.AddMvc(op =>
            {
                op.EnableEndpointRouting = false;
                foreach (var formatter in op.OutputFormatters
                        .OfType<ODataOutputFormatter>()
                        .Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue("application/prs.mock-odata"));
                }
                foreach (var formatter in op.InputFormatters
                    .OfType<ODataInputFormatter>()
                    .Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue("application/prs.mock-odata"));
                }
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.Use(async (HttpContext context, Func<Task> next) =>
            {
                await next.Invoke();

                if (context.Response.StatusCode == 404 && !context.Request.Path.Value.Contains("/api"))
                {
                    context.Request.Path = new PathString("/index.html");
                    await next.Invoke();
                }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseSwagger(x =>
            {
                x.SerializeAsV2 = true;
            }
            );
            app.UseSwaggerUI(swaggerAction => {
                swaggerAction.SwaggerEndpoint("/swagger/BDRestApi/swagger.json", "BDRestApi");
            });
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Expand().Select().Filter().Count().OrderBy();
            });
            //app.Map("", terminalApp =>
            //{
            //    terminalApp.UseSpa(spa =>
            //    {
            //        spa.Options.SourcePath = "wwwroot";
            //        spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
            //        {
            //            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot"))
            //        };
            //        if(env.IsDevelopment())
            //        {
            //            spa.UseProxyToSpaDevelopmentServer("http://localhost:60653");
            //        }
            //    });
            //});
        }
    }
}
