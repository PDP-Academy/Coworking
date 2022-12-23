using EventZone.Brokers;
using EventZone.Services.Users;
using EventZone.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(ConfigureServices)
    .Build();
await host.StartAsync();

var userViewService = host.Services
    .GetRequiredService<IUserView>();

//await userViewService.PrintUser();
//await userViewService.PrintSignUp();
await userViewService.PrintOrdersDay();

static void ConfigureServices(
    HostBuilderContext context,
    IServiceCollection services)
{
    services.AddScoped<IStorageBroker, StorageBroker>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IUserView, UserView>();
}