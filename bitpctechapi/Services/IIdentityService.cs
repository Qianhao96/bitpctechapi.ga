using bitpctechapi.Domain;
using System.Threading.Tasks;

namespace bitpctechapi.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
    }
}
