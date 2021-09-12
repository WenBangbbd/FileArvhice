using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace FileArchive.WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder()
                 .ConfigureWebHostDefaults(builder =>
                 {
                     builder.UseStartup<StartUp>();
 
                 })
                 .Build()
                 .Run();
        }
    }
}
