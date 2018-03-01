using System;

public class OutOfFuelException : Exception
{
    public override string Message => $"Out of fuel";
}

