using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.Versioning;
using back_end.Classes;

namespace back_end
{
    public class Startup
    {
        readonly string AllowedSpecificOrigins = "_allowedSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer().AddEntityFrameworkSqlServer().AddDbContext<DeviceContext>(options => options.UseSqlServer("Data:DefaultConnection:ConnectionString"));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //JSON Serializer
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());

            //Enable CORS
            services.AddCors(options =>
            {

                options.AddDefaultPolicy(
                    builder => {
                        //Angular front-end (default) origin point with ng serve --ssl true enabled
                        builder.WithOrigins("https://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    }
                );

                //for a specific named policy 
                /* options.AddPolicy(name: AllowedSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins(
                            "http://localhost:4200"
                           ).AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                    });
 */
            });


            services.AddAuthentication();
            services.AddRouting();
            services.AddControllers();

            services.AddApiVersioning(options => {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version");
            });
            services.AddVersionedApiExplorer(
                options => options.GroupNameFormat = "'v'VVV");

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "http://localhost:51959";
                    options.RequireHttpsMetadata = false;

                    options.Audience = "1Valet-api";

                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                })
                ;


            //to solve Post / Put problems in Postman testing, can be removed in post once it's alive on the server proper 
            services.AddMvcCore(options => options.SuppressAsyncSuffixInActionNames = false);

          
            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>>();

           // services.AddSwaggerGen(options =>
           //{
           //    options.OperationFilter<SwaggerDefaultValues>();
           //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //forces server to only accept https from client, esssentially kicking itno a high-security mode
            app.UseHsts();
            
            //standard re-direct back to https
            //app.UseHttpsRedirection();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
                RequestPath = "/Photos"
            });
            app.UseRouting();
            
            //Enable CORS
            app.UseCors();

            //for IdentityServer
            app.UseAuthentication();

            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/echo",
                context => context.Response.WriteAsync("echo"))
                .RequireCors(AllowedSpecificOrigins);

                endpoints.MapControllers()
                     .RequireCors(AllowedSpecificOrigins);

                endpoints.MapGet("/echo2",
                    context => context.Response.WriteAsync("echo2"));
            });

           
 /* app.UseSwagger();
            app.UseSwaggerUI(options => {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant()
                    );
                }
            }); */        }
    }
}
