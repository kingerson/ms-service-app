using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.OpenApi.Models;
using MsServiceApp.Application;
using MsServiceApp.Infraestructure;
using MsServiceApp.Infrastructure;
using MsServiceApp.Services;
using Serilog;

namespace MsServiceApp
{
    [ExcludeFromCodeCoverage]
    public static class ProgramExtensions
    {
        public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
        {
            #region Logging

                _ = builder.Host.UseSerilog((hostContext, loggerConfiguration) =>
                {
                    var assembly = Assembly.GetEntryAssembly();

                    _ = loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration)
                            .Enrich.WithProperty("Assembly Version", assembly?.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version)
                            .Enrich.WithProperty("Assembly Informational Version", assembly?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion);
                });

            #endregion Logging


            #region Serialisation

                _ = builder.Services.Configure<JsonOptions>(opt =>
                {
                    opt.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    opt.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    opt.SerializerOptions.PropertyNameCaseInsensitive = true;
                    opt.SerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
                    opt.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                });

            #endregion Serialisation

            _ = builder.Services.AddDistributedMemoryCache();

            #region Swagger

                _ = builder.Services.AddControllers().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.WriteIndented = true;
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;

                });

                _ = builder.Services.AddEndpointsApiExplorer();
                _ = builder.Services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1",
                        new OpenApiInfo
                        {
                            Version = "v1",
                            Title = "MS Service app",
                            Description = "MS Service app.",
                            Contact = new OpenApiContact
                            {
                                Name = "Gerson Navarro",
                                Email = "g.navarrope@gmail.com",
                                Url = new Uri("https://github.com/kingerson")
                            }
                        });

                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description =
                            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });


                    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                        }
                    });

                    options.OperationFilter<FileUploadOperationFilter>();
                    options.DocInclusionPredicate((name, api) => true);
                });

            #endregion Swagger

            #region Project Dependencies
            _ = builder.Services.AddHttpContextAccessor();
            _ = builder.Services.AddMemoryCache();

            _ = builder.Services.AddApplication();
            _ = builder.Services.AddInfrastructure(builder.Configuration);
            _ = builder.Services.AddServices();
            
            #endregion

            _ = builder.Services.AddHttpClient();

            _ = builder.Services.AddCors();
            return builder;
        }

        public static WebApplication ConfigureApplication(this WebApplication app)
        {
             #region Exceptions

            _ = app.UseGlobalExceptionHandler();

            #endregion Exceptions

             #region Logging

            _ = app.UseSerilogRequestLogging();

            #endregion Logging

            #region Swagger

            _ = app.UseSwagger();
            _ = app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"MS Service app - V1"));

            #endregion Swagger

            #region Security

            _ = app.UseHsts();

            #endregion Security

            _ = app.UseRouting();

            _ = app.UseHttpsRedirection();
            _ = app.MapControllers();

            _ = app.UseCors(builder => builder.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    );

            #region Initialize Data Base

            var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            InitializeData(context);

            #endregion 

            return app;
        }

        private static void InitializeData(ApplicationDbContext context)
        {
             var person = new Person();
             person.Register("Gerson","Navarro","g.navarrope@gmail.com");
             person.UserRegister = "user";
             person.DateTimeRegister = DateTime.Now;
             context.Add(person);
             context.SaveChanges();
        }
    }
}