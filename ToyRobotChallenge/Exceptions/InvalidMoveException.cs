﻿namespace ToyRobotChallenge.Exceptions;

[Serializable]
internal class InvalidMoveException : Exception 
{
    public InvalidMoveException(string message)
        : base(message) { }
}
