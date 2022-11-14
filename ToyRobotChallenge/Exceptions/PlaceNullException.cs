namespace ToyRobotChallenge.Exceptions;

[Serializable]
internal class PlaceNullException : Exception
{
    internal PlaceNullException(string message) : base(message) { }
}
