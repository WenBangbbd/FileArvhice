using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileArchive.WebApi.Filter
{
    public class SwaggerFileUploadFilter : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (!context.ApiDescription.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var fileParameters = context.ApiDescription.ActionDescriptor.Parameters
                .Where(n => n.ParameterType == typeof(IFormFile))
                .ToList();

            if (fileParameters.Count < 0)
            {
                return;
            }
            //operation.Consumes.Add("multipart/form-data");
            //operation.Consumes.Add("multipart/form-data");

            foreach (var fileParameter in fileParameters)
            {
                var content = operation.RequestBody.Content.SingleOrDefault(n => n.Value.Encoding.Keys.Contains(fileParameter.Name));
                if (content.Key != null)
                    operation.RequestBody.Content.Remove(content);

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "file",
                    Description = "上传文件",
                    Style = ParameterStyle.Form,
                    Schema = new OpenApiSchema
                    {
                        Type = "file",
                    }
                });
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "enctype",
                    In = ParameterLocation.Header,
                });
            }
        }
    }
}
