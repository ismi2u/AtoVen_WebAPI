using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AtoVen_WebAPI.Data;

namespace AtoVen_WebAPI
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AtoVen_WebAPI", Version = "v1" });
            });

            services.AddDbContext<AtoVen_WebAPIContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQLServerInLocalAppInContainer")));

             //services.AddDbContextPool<AtoCashDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalhostSQLServerConnectionString")));
           
            //        "AzureCloudGmailServer": "Server=20.198.65.162;Port=5432;Database=AtoCashDB;User Id=postgres;Password=Pa55word2019!123;Pooling=true;Timeout=300; CommandTimeout=300",
            //"GoogleCloudAtominosServer": "Server=20.198.65.162;Port=5432;Database=AtoCashDB;User Id=postgres;Password=Pa55word2019!123;Pooling=true;",
            //"PostgreSQLConnectionString": "Server=localhost;Port=5432;Database=AtoCashDB;User Id=postgres;Password=Pa55word2019!123;Pooling=true;",
            //"PostgreSQLInLocalAppInContainer": "Server=host.docker.internal;Port=5432;Database=AtoCashDB;User Id=postgres;Password=Pa55word2019!123;Pooling=true;",
            //"WithinContainerPostGreSQL": "Server=postgresdata;Port=5432;Database=AtoCashDB;User Id=postgres;Password=Pa55word2019!123;Pooling=true;Timeout=300; CommandTimeout=300"
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AtoVen_WebAPI v1"));
            }
            app.UseStaticFiles();


            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, @"Documents")),
                RequestPath = "/app/Documents"
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
