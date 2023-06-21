using CarriotTest.Db.Entities;
using Microsoft.AspNetCore.SignalR;

namespace CarriotTest.Models
{
    public interface IHubClient
    {
        Task SendTempLog(TempLog log);
        Task SendWarning(HasWarning warning);

    }
    public class BroadcastHub : Hub<IHubClient>
    {
        public async Task SendTempLog(TempLog log)
        {
            await Clients.All.SendTempLog(log);
        }
        public async Task SendWarning(HasWarning warning)
        {
            await Clients.All.SendWarning(warning);
        }
    }

}
