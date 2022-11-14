using ToyRobotChallenge.BusinessLogic.interfaces;
using ToyRobotChallenge.Enums;
using ToyRobotChallenge.Exceptions;
using ToyRobotChallenge.Models;

namespace ToyRobotChallenge.BusinessLogic;

internal class ToyRobotService : IToyRobotService
{
    private readonly IPositionService positionService;
    private readonly IValidMoveService validMoveService;


    public ToyRobotService(IPositionService positionService, IValidMoveService validMoveService)
    {
        this.positionService = positionService;
        this.validMoveService = validMoveService;
    }

    private static Direction Direction { get; set; }

    public void Move()
    {
        var position = positionService.GetPosition();

        if (position == null) throw new PlaceNullException("PLace needs to be called first");

        if (Direction == Direction.North)
            position.xAxis = position.xAxis + 1;
        if (Direction == Direction.South)
            position.xAxis = position.xAxis - 1;
        if (Direction == Direction.West)
            position.yAxis = position.yAxis - 1;
        if (Direction == Direction.East)
            position.yAxis = position.yAxis + 1;

        var validMove = validMoveService.IsValidMove(position);

        if (!validMove) throw new InvalidMoveException($"Place invalid {position.ToString()}");

        positionService.SetPosition(position);
    }

    public void Left()
    {
        if (Direction == Direction.North)
        {
            Direction = Direction.West;
            return;
        }
        if (Direction == Direction.South)
        {
            Direction = Direction.East;
            return;
        }
        if (Direction == Direction.West)
        {
            Direction = Direction.South;
            return;
        }
        if (Direction == Direction.East)
        {
            Direction = Direction.North;
            return;
        }
    }

    public void Right()
    {
        if (Direction == Direction.North)
        {
            Direction = Direction.East;
            return;
        }
        if (Direction == Direction.South)
        {
            Direction = Direction.West;
            return;
        }
        if (Direction == Direction.West)
        {
            Direction = Direction.North;
            return;
        }
        if (Direction == Direction.East)
        {
            Direction = Direction.South;
            return;
        }
    }

    public void Place(Position position, Direction direction)
    {
        var validMove = validMoveService.IsValidMove(position);

        if (!validMove) throw new InvalidMoveException($"Move invalid {position.ToString()} {direction.ToString()} " );

        positionService.SetPosition(position);
        Direction = direction;
    }

    public void SetDirection(Direction direction)
    {
        Direction = direction;
    }

    public Position GetPosition()
    {
        return positionService.GetPosition();
    }

    public Direction GetDirection()
    {
        return Direction;
    }
}
