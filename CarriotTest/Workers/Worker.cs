using CarriotTest.Broker;
using CarriotTest.Models;
using Microsoft.AspNetCore.SignalR;

namespace CarriotTest.Workers
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly IMQttClient _client;
        public Worker(ILogger<Worker> logger, IHubContext<BroadcastHub, IHubClient> hubContext, IMQttClient client)
        {
            _logger = logger;
            _hubContext = hubContext;
            _client = client;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           // Client_Connections client_Connections = new Client_Connections(_hubContext);
            await _client.Connect_Client();
           
        }
    }
}
