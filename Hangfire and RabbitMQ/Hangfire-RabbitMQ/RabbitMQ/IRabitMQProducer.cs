namespace Hangfire_RabbitMQ.RabbitMQ
{
    public interface IRabitMQProducer
    {
        public void SendUserMessage<T>(T message);
    }
}
