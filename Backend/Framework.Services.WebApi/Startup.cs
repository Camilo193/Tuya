using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using AutoMapper;

using Framework.Transversal.Mapper;
using Framework.Transversal.Common;
using Framework.InfraStructure.Data;
using Framework.InfraStructure.Repository;
using Framework.InfraStructure.Interface;
using Framework.Domain.Interface;
using Framework.Domain.Core;
using Framework.Application.Interface;
using Framework.Application.Main;
using System.Reflection;
using Framework.Services.WebApi.Helpers;

//using Swashbuckle.AspNetCore.Swagger;

using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Framework.Transversal.Logging;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Framework.Services.WebApi
{
    public class Startup
    {
        readonly string myPolicy = "policyApiGlobus";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSwaggerGen();
            //services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));
            //Conectarme a una base de datos con Entity Framework
            services.AddDbContextPool<EFConnectionFactory>(options => options.UseSqlServer(Configuration.GetConnectionString("TuyaSQLServer")));


            //services.AddAutoMapper(typeof(Startup));

            //services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(Configuration["Config:OriginCors"])
            //                                                                           .AllowAnyHeader()
            //                                                                           .AllowAnyMethod()));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowAnyOrigin()
                );
            });

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });

            //services.AddControllers();
            services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

            var appSettingsSection = Configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection);

            //configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();

            //Se especifican la vida útil de los servicios.
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            //Se usa de Scoped o de ámbito porque necesitamos que se instancie una vez por solicitud
            services.AddScoped<IClientesApplication, ClientesApplication>();
            services.AddScoped<IClientesDomain, ClientesDomain>();
            services.AddScoped<IClientesRepository, ClientesRepository>();

            services.AddScoped<IDetallesApplication, DetallesApplication>();
            services.AddScoped<IDetallesDomain, DetallesDomain>();
            services.AddScoped<IDetallesRepository, DetallesRepository>();

            services.AddScoped<IProductosApplication, ProductosApplication>();
            services.AddScoped<IProductosDomain, ProductosDomain>();
            services.AddScoped<IProductosRepository, ProductosRepository>();

            services.AddScoped<IFacturasApplication, FacturasApplication>();
            services.AddScoped<IFacturasDomain, FacturasDomain>();
            services.AddScoped<IFacturasRepository, FacturasRepository>();

            services.AddScoped<IInformacionFacturasApplication, InformacionFacturasApplication>();
            services.AddScoped<IInformacionFacturasDomain, InformacionFacturasDomain>();
            services.AddScoped<IInformacionFacturasRepository, InformacionFacturasRepository>();

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));


            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var IsSuer = appSettings.IsSuer;
            var Audience = appSettings.Audience;

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            var userId = int.Parse(context.Principal.Identity.Name);
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = IsSuer,
                        ValidateAudience = true,
                        ValidAudience = Audience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });



            ////Configuración de Swagger
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info
            //    {
            //        Version = "v1",
            //        Title = "Globus Sistemas S.A.S API Rest",
            //        Description = "API para el desarrollo y soluciones de las aplicaciones para Globus Sistemas S.A.S",
            //        TermsOfService = "None",
            //        Contact = new Contact
            //        {
            //            Name = "José Sandoval Isasa",
            //            Email = "jose.sandoval@globussistemas.net",
            //            Url = "http://globussistemas.net"
            //        },
            //        License = new License
            //        {
            //            Name = "Globus LICX",
            //            Url = "http://globussistemas.net/license"
            //        }
            //    });
            //    //Set the comments path for the Swagger JSON and UI.
            //    var xmlFile = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    c.IncludeXmlComments(xmlPath);
            //    //Definiendo Token en el Swagger    
            //    c.AddSecurityDefinition("Authorization", new ApiKeyScheme)
            //      {
            //          Description = "Authorization by API Key",
            //          In = "header",
            //          Type = "apiKey",
            //          Name = "Authorization"
            //      });
            //    c.AddSecurityRequirenment(new Directionary<string, IEnumerable<string>>
            //    {
            //      { "Authorization", new string[0] }
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ////Configuración Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseCors(myPolicy);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
