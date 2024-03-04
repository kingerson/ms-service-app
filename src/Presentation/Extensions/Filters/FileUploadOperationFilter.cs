using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MsServiceApp
{
    public class FileUploadOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.RelativePath.Contains("File") && context.ApiDescription.HttpMethod == "POST")
            {

                var uploadFileMediaType = new OpenApiMediaType()
                {
                    Schema = new OpenApiSchema()
                    {
                        Type = "object",
                        Properties =
                        {
                            ["file"] = new OpenApiSchema()
                            {
                                Description = "Upload File",
                                Type = "file",
                                Format = "formData"
                            },
                            ["idProspecto"] = new OpenApiSchema()
                            {
                                Description = "Id Prospecto",
                                Type = "guid",
                                Format = "formData"
                            },
                            ["idTipoDocumento"] = new OpenApiSchema()
                            {
                                Description = "Id TipoDocumento",
                                Type = "guid",
                                Format = "formData"
                            }
                        },
                        Required = new HashSet<string>(){  "file" , "idProspecto"}
                    }
                };

                operation.RequestBody = new OpenApiRequestBody
                {
                    Content = {  ["multipart/form-data"] = uploadFileMediaType  }
                };

            }
        }
    }
}