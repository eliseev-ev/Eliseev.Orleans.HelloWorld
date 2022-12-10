// See https://aka.ms/new-console-template for more information
using Eliseev.Orleans.HelloWorld.Models.Graints.Hello;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(client =>
    {
        client.UseLocalhostClustering();
    })
    .UseConsoleLifetime()
    .Build();

await host.StartAsync();

Console.WriteLine("Hello, World!");


var client = host.Services.GetRequiredService<IClusterClient>();

var room = Console.ReadLine();


while (true)
{
    var input = Console.ReadLine();
    var grain = client.GetGrain<IHelloGrain>(room);
    input = await grain.SayHello(input);
    Console.WriteLine(input);
}
