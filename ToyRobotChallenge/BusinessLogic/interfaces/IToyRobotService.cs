using ToyRobotChallenge.Enums;
using ToyRobotChallenge.Models;

namespace ToyRobotChallenge.BusinessLogic.interfaces;

internal interface IToyRobotService
{
    void Move();

    void Left();

    void Right();

    void Place(Position position, Direction direction);

    Position GetPosition();

    Direction GetDirection();

    void SetDirection(Direction direction);
}
