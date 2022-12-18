using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Security.Claims;
using System.Data;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using FluentValidation.AspNetCore;
using FluentValidation;
using Swashbuckle;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.ReDoc;
using Swashbuckle.AspNetCore.Swagger;
using Serilog;
using Serilog.AspNetCore;

using Amphibian.Oep.Configuration;
using Amphibian.Oep.Api.Repositories;
using Amphibian.Oep.Api.Services;
using Amphibian.Oep.Api.Controllers;
using Amphibian.Oep.Api.Validations;
using Amphibian.Oep.Api.Models;
using Amphibian.Oep.Api.Mappings;
using Amphibian.Oep.Api.Infrastructure;
using System.Reflection;
using System.Text.Json.Serialization;
using Amphibian.Oep.Api.Dtos;
using Dapper;
using Amphibian.Oep.Api.Extensions;
using Hangfire;
using Hangfire.AspNetCore;
using Ben.Diagnostics;

namespace Amphibian.Oep.Api
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
            var serviceConfiguration = new OepApiConfiguration();
            Configuration.Bind(serviceConfiguration);

            //pull secure things from env vars if we're not in dev
            //TODO: we can probably just do this with reflection, but this is faster
            //SetFromEnvVarIfAvailable<PatrolTrainingApiConfiguration>(serviceConfiguration, (c, s) => c.Email.SendGridApiKey = s, "Email.SendGridApiKey");
            //SetFromEnvVarIfAvailable<PatrolTrainingApiConfiguration>(serviceConfiguration, (c, s) => c.Database.ConnectionString = s, "Database.ConnectionString");

            services.AddSingleton(serviceConfiguration);

            services.AddControllers()
                .AddFluentValidation()
                .AddJsonOptions(options => {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Patrol.Ski Api", Version = serviceConfiguration.Version });
                c.AddSecurityDefinition("Authorization", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.Http,
                    Scheme="bearer",
                    BearerFormat="JWT",
                    In = ParameterLocation.Header,

                });
                //c.IncludeXmlComments("Amphibian.Oep.Api.xml", true);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                                Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Authorization"
                            }
                        }, new List<string>()
                    }
                });
            });

            services.AddAuthentication("BasicOrTokenAuthentication")
                .AddScheme<AuthenticationSchemeOptions, Infrastructure.AuthenticationHandler>("BasicOrTokenAuthentication", null);

            
            //db
            services.AddScoped<System.Data.Common.DbConnection, SqlConnection>(sp=>
            {
                var connection = new SqlConnection(serviceConfiguration.Database.ConnectionString);
                Dapper.SqlMapper.Settings.CommandTimeout = 0;
                return connection;
            });
            services.AddScoped<IUnitOfWork, DbUnitOfWork>();
            //automapper config
            services.AddMappings();
            //dapper config
            SqlMapper.AddTypeHandler(new DapperDateTimeHandler());
            
            services.AddSingleton<AuthenticationConfiguration>(serviceConfiguration.Authentication);
            services.AddSingleton<AppConfiguration>(serviceConfiguration.App);
            services.AddSingleton<EmailConfiguration>(serviceConfiguration.Email);

            //persistence
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IApiLogRepository, ApiLogRepository>();
            services.AddScoped<IFileUploadRepository, FileUploadRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IResponseRepository, ResponseRepository>();
            services.AddScoped<IGlossaryRepository, GlossaryRepository>();

            //validations
            services.AddScoped<IValidator<AuthenticationController.RegistrationRequest>, RegistrationValidator>();
            

            //services
            services.AddScoped<Services.IAuthenticationService, Services.AuthenticationService>();
            services.AddScoped<Services.IPasswordService, Services.PasswordService>(sp=>new Services.PasswordService(5,32));
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<IResponseService, ResponseService>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddScoped<ISysAdminService, SysAdminService>();
            

            services.AddScoped<ISystemClock, SystemClock>();

            //hangfire
            //services.AddHangfire(x => x.UseSqlServerStorage(serviceConfiguration.Database.ConnectionString)
            //.UseSerilogLogProvider());
            //services.AddHangfireServer();
            //RecurringJob.AddOrUpdate<Api.Jobs.CreateAvailableDemoPatrolJob>(job => job.Run(), "0 8 * * *");
            //RecurringJob.AddOrUpdate<Api.Jobs.DeleteUnusedDemoPatrolsJob>(job => job.Run(), "0 * * * *");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseBlockingDetection();
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();

            var appConfig = app.ApplicationServices.GetService<AppConfiguration>();

            string staticFilesPath=null;
            if (env.IsDevelopment() && Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "../Amphibian.Oep.Web/dist")))
            {
                app.UseDeveloperExceptionPage();
                staticFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "../Amphibian.Oep.Web/dist");

            }
            else if(Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "static")))
            {
                staticFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "static");
            }
            

            if (!string.IsNullOrEmpty(staticFilesPath) && Directory.Exists(staticFilesPath))
            {
                app.UseDefaultFiles(new DefaultFilesOptions()
                {
                    DefaultFileNames = new List<string>() { "index.html" },
                    FileProvider = new PhysicalFileProvider(staticFilesPath)
                });
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(staticFilesPath),
                });
            }

            //serve up user images.  NOT SECURE!  public events/announcements are not authenticated!
            if(!string.IsNullOrEmpty(appConfig.UserFilePath) && !string.IsNullOrEmpty(appConfig.UserFileRelativeUrl))
            {
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(appConfig.UserFilePath),
                    RequestPath = appConfig.UserFileRelativeUrl
                });
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            });
            app.UseReDoc(c =>
            {
                c.SpecUrl = "/swagger/v1/swagger.json";
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


            app.UseMiddleware<ApiLogMiddleware>();
            app.UseUnitOfWorkMiddleware(Assembly.GetAssembly(typeof(AuthenticationController)));
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseHangfireDashboard("/jobs", new DashboardOptions()
            //{
            //    Authorization = new[] { new HangfireAuthorizationFilter() }
            //});
            //RecurringJob.AddOrUpdate<Api.Jobs.CreateAvailableDemoPatrolJob>(job => job.Run(), "0 8 * * *");
            
            //BackgroundJob.Enqueue<Api.Jobs.CreateAvailableDemoPatrolJob>(job => job.Run());
        }
    }
}
