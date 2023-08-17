using miniblocks.API.Platform.Hosting;

var builder = Host.CreateClientBuilder();

using var host = builder.Build();
host.Run();
