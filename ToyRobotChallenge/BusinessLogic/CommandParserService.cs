using ToyRobotChallenge.BusinessLogic.interfaces;
using ToyRobotChallenge.Enums;
using ToyRobotChallenge.Exceptions;
using ToyRobotChallenge.Models;

namespace ToyRobotChallenge.BusinessLogic;

internal class CommandParserService : ICommandParserService
{
    public Command Parse(string text)
    {
        if (text.ToLower().Contains(AvailableCommands.Place.ToString().ToLower()))
        {
            Command command = new Command(AvailableCommands.Place);           
                       
            try
            {
                var commandMove = text.Split(" ");

                var commandParameters = commandMove[1].Split(',');

                command.Position = new Position(Int32.Parse(commandParameters[0].TrimEnd(',')), Int32.Parse(commandParameters[1].TrimEnd(',')));

                command.Direction = (Direction)Enum.Parse(typeof(Direction), commandParameters[2], true);
            }
            catch(Exception)
            {
                throw new PlaceParametersInvalidException($"Command: {text} is invalid");
            }

            return command;
        }

        if (text.ToLower().Contains(AvailableCommands.Move.ToString().ToLower()))
        {
            return new Command(AvailableCommands.Move);
        }

        if (text.ToLower().Contains(AvailableCommands.Left.ToString().ToLower()))
        {
            return new Command(AvailableCommands.Left);
        }

        if (text.ToLower().Contains(AvailableCommands.Right.ToString().ToLower()))
        {
            return new Command(AvailableCommands.Right);
        }

        if (text.ToLower().Contains(AvailableCommands.Report.ToString().ToLower()))
        {
            return new Command(AvailableCommands.Report);
        }

        throw new CommandNotKnownException($"Command: {text} unrecognised");
    }
}
