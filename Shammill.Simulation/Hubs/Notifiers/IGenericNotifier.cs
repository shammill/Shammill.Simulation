using System.Threading.Tasks;

namespace Shammill.Simulation.Hubs.Notifiers
{
    public interface IGenericNotifier
    {
        Task SendMessageToUser<T>(string userId, T message);
        Task SendMessageToGroup<T>(string group, T message);
        Task SendMessageToAll<T>(T message);
    }
}