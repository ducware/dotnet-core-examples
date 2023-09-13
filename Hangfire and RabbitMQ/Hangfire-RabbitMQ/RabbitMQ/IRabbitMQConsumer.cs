namespace Hangfire_RabbitMQ.RabbitMQ
{
    public interface IRabbitMQConsumer
    {
        public T GetUserMessage<T>();
    }
}
