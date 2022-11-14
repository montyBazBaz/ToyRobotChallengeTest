using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ToyRobotChallenge.BusinessLogic.interfaces;

namespace ToyRobotChallenge;

internal class Startup : IHostedService
{
    public IToyRobotCommandService toyRobotCommandService;

    public Startup(IToyRobotCommandService toyRobotCommandService)
    {       
        this.toyRobotCommandService = toyRobotCommandService;
    }
       
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Task.Run(() => Start(cancellationToken));
        return Task.CompletedTask;      
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
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
