using System.Threading.Tasks;

namespace RazorComponentsRealWorld.Services
{
    public interface IConsoleLogService
    {
        Task<bool> LogAsync(string LogString);
    }
}
