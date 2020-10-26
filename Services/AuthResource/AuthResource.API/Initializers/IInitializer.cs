using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthResource.API.Initializers
{
    public interface IInitializer {
        void InitializeServices(IServiceCollection services, IConfiguration configuration);
    }
}
