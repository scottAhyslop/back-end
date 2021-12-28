using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using NSwag;

public class ConfigureSwaggerOptions : IConfigureOptions<ConfigureSwaggerOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    public void Configure(ConfigureSwaggerOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
           /*  options.SwaggerDoc(
                description.GroupName,
                new OpenApiInfo(){
                    Title = $"1Valet API {description.ApiVersion}",
                    Version = description.ApiVersion.ToString()
                }
            ); */
        }
    }
}