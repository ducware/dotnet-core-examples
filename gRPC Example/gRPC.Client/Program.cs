using Grpc.Net.Client;
using GrpcService;
var message = new HelloRequest
{
    Name = "Dang Minh Duc"
};
var channel = GrpcChannel.ForAddress("http://localhost:5056");
var client = new Greeter.GreeterClient(channel);
var srerveReply = await client.SayHelloAsync(message);
Console.WriteLine(srerveReply.Message);
Console.ReadLine();