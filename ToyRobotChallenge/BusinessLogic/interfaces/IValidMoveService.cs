using System.Runtime.CompilerServices;
using ToyRobotChallenge.Models;

[assembly: InternalsVisibleTo("UnitTests")]
namespace ToyRobotChallenge.BusinessLogic.interfaces;

internal interface IValidMoveService
{
    bool IsValidMove(Position position);
}
