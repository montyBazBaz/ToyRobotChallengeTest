using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ToyRobotChallenge.BusinessLogic.interfaces;
using ToyRobotChallenge.Models;
using ToyRobotChallenge.Settings;

namespace ToyRobotChallenge.BusinessLogic;

internal class ValidMoveService : IValidMoveService
{
    private TableSettings table = new TableSettings();

    public ValidMoveService(IOptions<TableSettings> settings)
    {
        table = settings.Value;

        table.yAxis--;
        table.xAxis--;
    }

    public bool IsValidMove(Position position)
    {
        if (position.xAxis < 0) return false;
        if (position.yAxis < 0) return false;

        if (position.xAxis > table.xAxis) return false;
        if (position.yAxis > table.yAxis) return false;

        return true;
    }
}
