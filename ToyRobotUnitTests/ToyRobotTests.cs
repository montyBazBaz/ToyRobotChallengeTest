using FluentAssertions;
using Moq;
using ToyRobotChallenge.BusinessLogic;
using ToyRobotChallenge.BusinessLogic.interfaces;
using ToyRobotChallenge.Enums;
using ToyRobotChallenge.Exceptions;
using ToyRobotChallenge.Models;

namespace UnitTests;

public class ToyRobotTests
{
    private ToyRobotService toyRobotService;

    private Mock<IPositionService> positionServiceMock;
    private Mock<IValidMoveService> validMoveServiceMock;

    [SetUp]
    public void Setup()
    {
        positionServiceMock = new Mock<IPositionService>();
        validMoveServiceMock = new Mock<IValidMoveService>();

        toyRobotService = new ToyRobotService(positionServiceMock.Object, validMoveServiceMock.Object);
    }

    [Test]
    public void Given_Position_Called_Sets_Position()
    {
        validMoveServiceMock.Setup(x => x.IsValidMove(It.IsAny<Position>())).Returns(true);

        var position = new Position(0, 0);

        toyRobotService.Place(position, ToyRobotChallenge.Enums.Direction.South);

        Position positionPassed = position;
        positionServiceMock.Setup(x => x.SetPosition(It.IsAny<Position>())).Callback<Position>(x => positionPassed = x);

        positionPassed.Should().BeEquivalentTo(position);
    }

    [Test]
    public void Given_Position_Invalid_Should_Throw()
    {
        validMoveServiceMock.Setup(x => x.IsValidMove(It.IsAny<Position>())).Returns(false);

        var position = new Position(0, 0);

        var act = () => toyRobotService.Place(position, ToyRobotChallenge.Enums.Direction.South);

        Position positionPassed = null;
        positionServiceMock.Setup(x => x.SetPosition(It.IsAny<Position>())).Callback<Position>(x => positionPassed = x);

        act.Should().Throw<InvalidMoveException>();
    }

    [Test]
    public void Given_Position_Null_Should_Throw()
    {
        validMoveServiceMock.Setup(x => x.IsValidMove(It.IsAny<Position>())).Returns(false);

        var position = new Position(0, 0);

        var act = () => toyRobotService.Place(position, ToyRobotChallenge.Enums.Direction.South);

        Position positionPassed = null;
        positionServiceMock.Setup(x => x.SetPosition(It.IsAny<Position>())).Callback<Position>(x => positionPassed = x);

        act.Should().Throw<InvalidMoveException>();
    }

    [TestCase(2,2,Direction.North)]
    [TestCase(2, 2, Direction.South)]
    [TestCase(2, 2, Direction.East)]
    [TestCase(2, 2, Direction.West)]
    public void Given_Move_Should_Move_One(int xAxis, int yAxis, Direction direction)
    {
        Position position = new Position(xAxis, yAxis);

        Position expectedposition = null;

        if (direction == Direction.North)
        {
            expectedposition = new Position(xAxis + 1, yAxis);
        }
        if (direction == Direction.South)
        {
            expectedposition = new Position(xAxis - 1, yAxis);
        }
        if (direction == Direction.East)
        {
            expectedposition = new Position(xAxis, yAxis + 1);
        }
        if (direction == Direction.West)
        {
            expectedposition = new Position(xAxis, yAxis - 1);
        }

        positionServiceMock.Setup(x => x.GetPosition()).Returns(position);

        validMoveServiceMock.Setup(x => x.IsValidMove(It.IsAny<Position>())).Returns(true);

        Position positionPassed = null;
        positionServiceMock.Setup(x => x.SetPosition(It.IsAny<Position>())).Callback<Position>(x => positionPassed = x);

        toyRobotService.SetDirection(direction);
        toyRobotService.Move();
              
        positionPassed.Should().BeEquivalentTo(expectedposition);
    }

    [Test]
    public void Given_Move_Invalid_Should_Throw()
    {
        validMoveServiceMock.Setup(x => x.IsValidMove(It.IsAny<Position>())).Returns(false);

        var position = new Position(0, 0);

        var act = () => toyRobotService.Place(position, ToyRobotChallenge.Enums.Direction.South);

        Position positionPassed = null;
        positionServiceMock.Setup(x => x.SetPosition(It.IsAny<Position>())).Callback<Position>(x => positionPassed = x);

        act.Should().Throw<InvalidMoveException>();
    }

    [TestCase(Direction.North, Direction.West)]
    [TestCase(Direction.West, Direction.South)]
    [TestCase(Direction.South, Direction.East)]
    [TestCase(Direction.East, Direction.North)]
    public void Given_Left_Called_Shoule_Rotate_Left(Direction current, Direction newDirection)
    {
        toyRobotService.SetDirection(current);

        toyRobotService.Left();

        var direction = toyRobotService.GetDirection();
        direction.Should().Be(newDirection);
    }

    [TestCase(Direction.North, Direction.East)]
    [TestCase(Direction.West, Direction.North)]
    [TestCase(Direction.South, Direction.West)]
    [TestCase(Direction.East, Direction.South)]
    public void Given_Right_Called_Shoule_Rotate_Right(Direction current, Direction newDirection)
    {
        toyRobotService.SetDirection(current);

        toyRobotService.Right();

        var direction = toyRobotService.GetDirection();
        direction.Should().Be(newDirection);
    }
}