using ToyRobotChallenge.BusinessLogic.interfaces;
using ToyRobotChallenge.Models;

namespace ToyRobotChallenge.BusinessLogic;

internal class PositionService : IPositionService
{
    private Position CurrentPosition; 

    public PositionService()
    {       
    }

    public Position GetPosition()
    {
        return CurrentPosition;
    }

    public void SetPosition(Position position)
    {
        CurrentPosition = position;
    }
}
