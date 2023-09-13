using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Hangfire_RabbitMQ.RabbitMQ
{
    public class RabbitMQConsumer : IRabbitMQConsumer
    {

        public T GetUserMessage<T>()
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

            var consumer = new EventingBasicConsumer(channel);
            var receivedMessage = default(T);

        BasicGetResult result = channel.BasicGet("user", autoAck: false);
        if (result != null)
        {
            var body = result.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            receivedMessage = Deserialize<T>(message);

            // Xác nhận tin nhắn đã được xử lý
            channel.BasicAck(result.DeliveryTag, multiple: false);
        }

        return receivedMessage;
        }

        private T Deserialize<T>(string message)
        {
            return JsonConvert.DeserializeObject<T>(message);
        }
    }
}
