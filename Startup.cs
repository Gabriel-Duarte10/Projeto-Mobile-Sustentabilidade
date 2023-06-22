using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Projeto_Mobile_Sustentabilidade.Data.Context;
using Projeto_Mobile_Sustentabilidade.Data.Interface;
using Projeto_Mobile_Sustentabilidade.Data.Repositorio;
using Projeto_Mobile_Sustentabilidade.Services;

namespace Projeto_Mobile_Sustentabilidade
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHttpContextAccessor();
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Base")));

            services.AddControllers((options => {
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
                options.EnableEndpointRouting = false;
            })).AddNewtonsoftJson();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMvcCore().AddRazorViewEngine();

            #region HangFire

            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("Hangfire")));
            services.AddHangfireServer();
            
            #endregion

            #region Cors

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin());
            });

            #endregion

            #region Interfaces e serviços


            services.AddScoped<IUsuario, UsuarioRep>();
            services.AddScoped<ILiquido, LiquidoRep>();
            services.AddScoped<IUsina, UsinaRep>();
            services.AddScoped<IPosto, PostoRep>();
            services.AddScoped<ICliente, ClienteRep>();
            services.AddScoped<IFuncionarioPosto, FuncionarioPostoRep>();
            services.AddScoped<IManterConta, ManterContaRep>();
            services.AddScoped<IDashboard, Dashboard>();
            services.AddScoped<IViewRenderService, ViewRenderService>();
            
            services.AddScoped<SendEmailService>();
            services.AddScoped<SendGridService>();
            services.AddScoped<ViewRenderService>();
            
            #endregion

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Projeto Mobile Sustentabilidade", Version = "v1" });
                c.CustomSchemaIds(x => x.FullName);
            });

            #endregion

            services.AddHttpsRedirection(options =>
            {
                options.HttpsPort = 7257;
            });
            

        }
         // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.Urls.Clear();
                app.Urls.Add("https://localhost:7257");
                app.Urls.Add("http://*:5031");
                app.Urls.Add("https://*:3434");
            }

            if (app.Environment.IsProduction())
            {
                app.UseHttpsRedirection();   
            }

            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Mobile Sustentabilidade");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                c.ShowExtensions();
                c.EnableFilter();
                c.EnableDeepLinking();
                c.EnableValidator();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (env.IsProduction())
            {
                app.UseSpa(conf => { });
            }
            app.UseHangfireServer();
            app.UseHangfireDashboard();

        }
    }
}