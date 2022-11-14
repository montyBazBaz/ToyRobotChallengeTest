namespace ToyRobotChallenge.Models;

internal class Position
{
    public int xAxis { get; set; }
    public int yAxis { get; set; }

    public Position() { }

    public Position(int xAxis, int yAxis)
    {
        this.xAxis = xAxis;
        this.yAxis = yAxis;
    }
}
