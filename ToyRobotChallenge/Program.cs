using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ToyRobotChallenge.BusinessLogic;
using ToyRobotChallenge.BusinessLogic.interfaces;
using ToyRobotChallenge.Settings;

namespace ToyRobotChallenge;

class Program
{
    public static IConfigurationRoot Configuration { get; set; }

    static async Task Main(string[] args)
    {       
        await CreateHostBuilder(args).RunConsoleAsync();
    }      

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        string projectDir =
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));

       var builder = new ConfigurationBuilder().SetBasePath(projectDir)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        Configuration = builder.Build();
        var settings = new TableSettings();

        return Host.CreateDefaultBuilder(args)          

            .UseConsoleLifetime()
            .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning))
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Startup>();
                services.AddSingleton<ICommandParserService, CommandParserService>();
                services.AddSingleton<IPositionService, PositionService>();
                services.AddSingleton<IToyRobotCommandService, ToyRobotCommandService>();
                services.AddSingleton<IToyRobotService, ToyRobotService>();
                services.AddSingleton<IValidMoveService, ValidMoveService>();
                services.AddSingleton(hostContext.Configuration);
                services.AddSingleton(Console.Out);
                services.AddOptions();           
                services.Configure<TableSettings>(Configuration.GetSection("TableSettings"));
            });       
    }
}