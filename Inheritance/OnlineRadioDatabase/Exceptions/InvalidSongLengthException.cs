﻿public abstract class InvalidSongLengthException : InvalidSongException
{
    public override string Message => $"Invalid song length.";
}

