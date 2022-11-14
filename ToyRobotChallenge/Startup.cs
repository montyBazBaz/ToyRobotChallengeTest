using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ToyRobotChallenge.BusinessLogic.interfaces;

namespace ToyRobotChallenge;

internal class Startup : IHostedService
{
    private CancellationTokenSource cts = new CancellationTokenSource();
    public IToyRobotCommandService toyRobotCommandService;

    public Startup(IToyRobotCommandService toyRobotCommandService)
    {       
        this.toyRobotCommandService = toyRobotCommandService;
    }
       
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Started...");
        Task.Run(() => Start(cancellationToken));
        return Task.CompletedTask;      
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        try
        {
            cts.Cancel();
        }
        finally
        {            
        }

        return Task.CompletedTask;
    }

    public void Start(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {           
            try
            {
                toyRobotCommandService.Command(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           
        }     
    }
}
