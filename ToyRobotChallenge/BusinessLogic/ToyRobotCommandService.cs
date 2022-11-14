using ToyRobotChallenge.BusinessLogic.interfaces;
using ToyRobotChallenge.Enums;

namespace ToyRobotChallenge.BusinessLogic;

internal class ToyRobotCommandService : IToyRobotCommandService
{ 
    IToyRobotService ToyRobotService;

    ICommandParserService commandParserService;

    public ToyRobotCommandService(IToyRobotService toyRobotService, ICommandParserService commandParserService)
    {       
        this.ToyRobotService = toyRobotService;
        this.commandParserService = commandParserService;
    }

    public void Command(string commandText)
    {
        var command = this.commandParserService.Parse(commandText);

        if (command.AvailableCommands == AvailableCommands.Place)
        {           
            ToyRobotService.Place(command.Position, command.Direction.Value);
            return;
        }

        if (command.AvailableCommands == AvailableCommands.Move)
        {
            ToyRobotService.Move();
            return;
        }

        if (command.AvailableCommands == AvailableCommands.Left)
        {
            ToyRobotService.Left();
            return;
        }

        if (command.AvailableCommands == AvailableCommands.Right)
        {
            ToyRobotService.Right();
            return;
        }

        if (command.AvailableCommands == AvailableCommands.Report)
        {
            var position = ToyRobotService.GetPosition();
            var direction = ToyRobotService.GetDirection();

            Console.Write($"Output: {position.xAxis}, {position.yAxis}, {direction.ToString()}");
            return;
        }
    }
}
