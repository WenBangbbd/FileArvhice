
using FileArchive.FileService;
using FileArchive.FileService.Abstract;
using FileArchive.FileService.AutoMapper;
using Microsoft.Extensions.FileProviders;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
   public static class ServiceCollectonExtension
    {
        public static IServiceCollection AddFileServices(this IServiceCollection services,Action<FileServiceOptions> fileServiceAction=null)
        {
            //var serviceOptions = new FileServiceOptions();
            //fileServiceAction?.Invoke(serviceOptions);
            //services.ConfigureOptions(serviceOptions);
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFileArchiveProvider, PhysicFileOperator>();
            services.AddScoped<IFileArchiveSaver, PhysicFileOperator>();
            services.AddScoped<IFileUUIdCreator, FileUUIdCreator>();
            services.AddAutoMapper(typeof(FileServiceProfile)) ;
            return services;
        }
    }
}
