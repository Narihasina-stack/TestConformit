using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProgrammationConformit.Commons.Service.Evenement;
using TestProgrammationConformit.Infrastructures;
using TestProgrammationConformit.Repositories.Personne;
using TestProgrammationConformit.Repositories.Commentaire;
using TestProgrammationConformit.Repositories.Evenement;
using TestProgrammationConformit.Commons.Service.Personne;
using AutoMapper;
using TestProgrammationConformit.Commons.Service.Commentaire;
using Swashbuckle;
using Microsoft.OpenApi.Models;
using System.IO;

namespace TestProgrammationConformit
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

            services.AddDbContext<ConformitContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("ConformitDb"),
                    npgsqlOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                    });
            });

            
            services.AddScoped(typeof(IPersonneRepository), typeof(PersonneRepository));
            services.AddScoped(typeof(ICommentaireRepository), typeof(CommentaireRepository));
            services.AddScoped(typeof(IEvenementRepository), typeof(EvenementRepository));

            services.AddScoped(typeof(IEvenementService), typeof(EvenementService));
            services.AddScoped(typeof(IPersonneService), typeof(PersonneService));
            services.AddScoped(typeof(ICommentaireService), typeof(CommentaireService));

            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

           // app.UseMiddleware<ApplicationFiler>()

        }


    }
}
