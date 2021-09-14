using FileArchive.FileService;
using FileArchive.WebApi.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.OpenApi.Models;
using System;

namespace FileArchive.WebApi
{
    public class StartUp
    {
        [Obsolete]
        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });
        public IConfiguration Configuration { get; set; }

        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();    //是否开发环境
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FileArchive.WebApi v1"));
            }
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication2", Version = "v1" });
                //c.OperationFilter<SwaggerFileUploadFilter>();
            });

            var fileOptions = Configuration.GetSection(FileServiceOptions.Position);
            services.Configure<FileServiceOptions>(fileOptions);
            //services.AddFileServices();
            //services.AddFileRepositories(builder =>
            //{
            //    builder.UseSqlServer("Data Source=localhost;Initial Catalog=fileArchive;Persist Security Info=True;User ID=sa;Password=123456;MultipleActiveResultSets=True");
            //});

            services.AddApplicationServices(builder =>
            {
                builder
                .UseSqlServer("Data Source=localhost;Initial Catalog=fileArchive;Persist Security Info=True;User ID=sa;Password=123456;MultipleActiveResultSets=True")
                .UseLoggerFactory(LoggerFactory);
            });

        }
    }
}