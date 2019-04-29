using System.Threading.Tasks;

namespace BlazorServerSideRealWorld.Services
{
    public interface IConsoleLogService
    {
        Task<bool> LogAsync(string LogString);
    }
}
