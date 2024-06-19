using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAssemblyDemo.Client.StateStore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<ContainerStorage>();

await builder.Build().RunAsync();
