using ServerManagement.Components;
using ServerManagement.StateStore;
using ServerManagement.StateStore.ServersStateStore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // add for server interactivity

//need to add dependency to cascade across render mode boundary
//builder.Services.AddCascadingValue("SelectedCity", sp => "Toronto");

builder.Services.AddTransient<SessionStorage>();

// AddScoped lifespan is the same as the SignalR lifespan
// we want this with ContainerStorage
// for server interactivity
builder.Services.AddScoped<ContainerStorage>();
// for web assembly interactivity
//builder.Services.AddSingleton<ContainerStorage>();
builder.Services.AddScoped<TorontoOnlineServersStore>();
builder.Services.AddScoped<MontrealOnlineServersStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // add for server interactivity

app.Run();
