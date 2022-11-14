
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using ToyRobotChallenge.BusinessLogic;
using ToyRobotChallenge.BusinessLogic.interfaces;
using ToyRobotChallenge.Models;

namespace UnitTests;

internal class ValidMoveServiceTests
{
    private IValidMoveService validMoveService;

    private IOptions<TableSettings> tableSettingsOptions;

    [SetUp]
    public void Setup()
    {
        var tableSettings = new TableSettings()
        {
            xAxis = 5,
            yAxis = 5,
        };

        tableSettingsOptions = Options.Create(tableSettings);
                
        this.validMoveService = new ValidMoveService(tableSettingsOptions);             
    }

    [TestCase(-1, 0, false)]
    [TestCase(0, 0, true)]
    [TestCase(1, 0, true)]
    [TestCase(2, 0, true)]
    [TestCase(3, 0, true)]
    [TestCase(4, 0, true)]
    [TestCase(5, 0, false)]
    [TestCase(0, -1, false)]
    [TestCase(0, 0, true)]
    [TestCase(0, 1, true)]
    [TestCase(0, 2, true)]
    [TestCase(0, 3, true)]
    [TestCase(0, 4, true)]
    [TestCase(0, 5, false)]
    public void Given_Position_Is_In_X_Axis_Y_Axis_Assert_Response(int xAxis, int yAxis, bool expectedResult)
    {
        var position = new Position(xAxis, yAxis);
        var response = this.validMoveService.IsValidMove(position);

        response.Should().Be(expectedResult);
    }
}
