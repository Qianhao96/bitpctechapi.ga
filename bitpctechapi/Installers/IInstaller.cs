using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PcPart.Installers
{
    public interface IInstaller
    {
        void Installservices(IServiceCollection service, IConfiguration configuration);
    }
}