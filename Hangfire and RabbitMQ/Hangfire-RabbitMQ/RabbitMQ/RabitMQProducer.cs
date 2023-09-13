using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Hangfire_RabbitMQ.RabbitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public void SendUserMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/"
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("user", exclusive: false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the user queue
            channel.BasicPublish(exchange: "", routingKey: "user", body: body);
        }
    }
}
