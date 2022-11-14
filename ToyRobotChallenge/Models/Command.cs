using ToyRobotChallenge.Enums;

namespace ToyRobotChallenge.Models;

internal class Command
{
    public AvailableCommands AvailableCommands { get; set; }

    public Position? Position { get; set; }

    public Direction? Direction { get; set; }   
    
    public Command(AvailableCommands commandType)
    {
        AvailableCommands = commandType;
        Position = null;
        Direction = null;
    }
}
