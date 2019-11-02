using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bitpctechapi.Installers
{
    public interface IInstaller
    {
        void Installservices(IServiceCollection service, IConfiguration configuration);
    }
}