using System.Threading.Tasks;

namespace RazorComponentsRealworld.Services
{
    public interface IConsoleLogService
    {
        Task<bool> LogAsync(string LogString);
    }
}
