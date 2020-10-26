using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AuthResource.API.Initializers
{
    public class SwaggerUIInitializer : IInitializer {
        public void InitializeServices(IServiceCollection services, IConfiguration configuration) {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "AuthResource Resource",
                    Description = "AuthResource API Documentation",
                    Contact = new OpenApiContact() {
                        Name = "Evan Vaughan",
                        Email = "evm.vaughan@gmail.com",
                        Url = new System.Uri("https://github.com/evaughan00")
                    },
                    License = new OpenApiLicense {
                        Name = "MIT",
                        Url = new System.Uri("https://opensource.org/licenses/MIT")
                    },
                });               
            });
        }
    }
}
