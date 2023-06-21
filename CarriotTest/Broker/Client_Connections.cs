using MQTTnet.Client;
using MQTTnet.Formatter;
using MQTTnet;
using MQTTnet.Extensions.WebSocket4Net;

using System.Security.Authentication;

using System.Text;
using StackExchange.Redis;
using System.Text.Json;
using CarriotTest.Models;
using Microsoft.AspNetCore.SignalR;
using CarriotTest.Db.Entities;
using CarriotTest.Services;

namespace CarriotTest.Broker
{
    public interface IMQttClient
    {
        public Task Connect_Client();
    }
    public class Client_Connections : IMQttClient
    {
        IHubContext<BroadcastHub, IHubClient> _hubContext;
        readonly IWarningService _warningService;
        readonly ITempLogService _tempLogService;

        IList<TempLog> _tempLogs;
        IList<HasWarning> _hasWarnings;

        public Client_Connections(
            IHubContext<BroadcastHub, IHubClient> hubContext
            , IWarningService warningService, ITempLogService tempLogService
            )
        {
            _hubContext = hubContext;
            _warningService = warningService;
            _tempLogService = tempLogService;
            _tempLogs = new List<TempLog>();
            _hasWarnings = new List<HasWarning>();
        }


        public async Task Connect_Client()
        {

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect($"{RedisConfig.Address}:{RedisConfig.Port}, password={RedisConfig.Password}");

            ISubscriber subScriber = redis.GetSubscriber();




            subScriber.Subscribe(ConstsRedisChannel.DetectionQueueChannel, (channel, message) =>
            {
                var data = JsonSerializer.Deserialize<HasWarning>(message);
                _hubContext.Clients.All.SendWarning(data);

                _hasWarnings.Add(data);

                if (_hasWarnings.Count > 10)
                {
                    _warningService.Insert(_hasWarnings) ;
                    _hasWarnings.Clear();
                }
                Console.WriteLine(message);
            });

            var mqttFactory = new MqttFactory();

            var mqttClientOptions = new MqttClientOptionsBuilder()
         .WithTcpServer(MQTTConfig.Address, MQTTConfig.Port)
         .WithCredentials(MQTTConfig.Username, MQTTConfig.Password)
         .Build();
            var mqttClient = mqttFactory.CreateMqttClient();
            // Setup message handling before connecting so that queued messages
            // are also handled properly. When there is no event handler attached all
            // received messages get lost.
            mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                Console.WriteLine($"Received application message at: {DateTime.UtcNow}");
                //e.DumpToConsole();
                // var t=   JsonSerializer.Deserialize<TempLogDto>(  Encoding.UTF8.GetString(e.ApplicationMessage.Payload)) ;

                // var data = JsonSerializer.Serialize(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));

                var message = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

                var r = subScriber.Publish(ConstsRedisChannel.HasWarningsQueueChannel, message);

                var data = JsonSerializer.Deserialize<TempLog>(message);
                _tempLogs.Add(data);

                if (_tempLogs.Count > 100)
                {
                    _tempLogService.Insert(_tempLogs) ;
                    _tempLogs.Clear();
                }

                _hubContext.Clients.All.SendTempLog(data);

                return Task.CompletedTask;
            };

            await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

            var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                .WithTopicFilter(
                    f =>
                    {
                        f.WithTopic(MQTTConfig.Topic);
                    })
            .Build();

            await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);



        }




    }
}
