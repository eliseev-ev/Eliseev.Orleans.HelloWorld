using Eliseev.Orleans.HelloWorld;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder(args)
    .UseOrleans(siloBuilder =>
    {
        siloBuilder
            .UseLocalhostClustering()
            .AddAdoNetGrainStorage("OrleansStorage", options =>
            {
                options.Invariant = AdoNetConfigurationInvariant.Postgres;
                options.ConnectionString = "User ID=playground_user;Password=password;Server=localhost;Port=5432;Database=orleans2;Integrated Security=true;Pooling=true;";
                //options.UseJsonFormat = true;
            });
    })
    .RunConsoleAsync();

// Configure the host
//using var host = new HostBuilder()
//    .UseOrleans(builder => 
//        builder
//        .UseLocalhostClustering())
//    .Build();

//// Start the host
//await host.StartAsync();

//// Get the grain factory
//var grainFactory = host.Services.GetRequiredService<IGrainFactory>();

//// Get a reference to the HelloGrain grain with the key "friend"
//var friend = grainFactory.GetGrain<IHelloGrain>("friend");

//// Call the grain and print the result to the console
//var result = await friend.SayHello("Good morning!");
//Console.WriteLine($"""

//    {result}

//    """);

//Console.WriteLine("Orleans is running.\nPress Enter to terminate...");
//Console.ReadLine();
//Console.WriteLine("Orleans is stopping...");

//await host.StopAsync();
