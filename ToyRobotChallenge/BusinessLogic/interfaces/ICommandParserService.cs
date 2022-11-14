using ToyRobotChallenge.Enums;
using ToyRobotChallenge.Models;

namespace ToyRobotChallenge.BusinessLogic.interfaces;

internal interface ICommandParserService
{
    Command Parse(string command);
}
