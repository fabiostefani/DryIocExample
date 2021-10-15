using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DryIoCExample.Infra
{
    public static class DryIocExtensions
    {
        public static IHostBuilder UseDryIoc(this IHostBuilder hostBuilder, IContainer preConfiguredContainer, IServiceProviderFactory<IContainer> factory = null)        
        {
            return hostBuilder.UseServiceProviderFactory(factory ?? new DryIocServiceProviderFactory(preConfiguredContainer));            
        }

        public static IHostBuilder UseDryIoc(this IHostBuilder hostBuilder, IServiceProviderFactory<IContainer> factory = null)
        {            
            return hostBuilder.UseServiceProviderFactory(factory ?? new DryIocServiceProviderFactory());
        }

        public static IContainer CreateMyPreConfiguredContainer() =>            
            new Container(rules =>              
                rules.With(propertiesAndFields: request =>
                    request.ServiceType.Name.EndsWith("Controller") ? PropertiesAndFields.Properties()(request) : null)
            );    
    }

    
}