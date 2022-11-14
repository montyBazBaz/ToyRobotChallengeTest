using System.Runtime.CompilerServices;
using ToyRobotChallenge.Models;

[assembly: InternalsVisibleTo("UnitTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace ToyRobotChallenge.BusinessLogic.interfaces;

internal interface IPositionService
{
    Position GetPosition();

    void SetPosition(Position position);
}
