using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7095");
var client = new Clients.ClientsClient(channel);
var reply = await client.CreateClientAsync(
                  new ClientInfo { Name = "Hansuja" });
Console.WriteLine("New Client Id: " + reply.Value);


var clientInfo = await client.GetClientAsync(reply);
Console.WriteLine("Data From DB: " + clientInfo.Name);


Console.WriteLine("Press any key to exit...");
Console.ReadKey();
