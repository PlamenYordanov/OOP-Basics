﻿using System;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double Length
    {
        get { return this.length; }
        private set
        {
            if (value <= 0)
            {
                Console.WriteLine("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }

    public double Width
    {
        get { return this.width; }
        private set
        {
            if (value <= 0)
            {
                Console.WriteLine("Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }

    public double Height
    {
        get { return this.height; }
        private set
        {
            if (value <= 0)
            {
                Console.WriteLine("Height cannot be zero or negative.");
                
            }
            this.height = value;
        }
    }
    

    public double SurfaceArea()
    {
        double area = (2 * this.length * this.width) + (2 * this.length * this.height) + (2 * this.width * this.height);
        return area;
    }
    public double LiteralSurfaceArea()
    {
        double literalArea = (2 * this.length * this.height) + (2 * this.width * this.height);
        return literalArea;
    }

    public double Volume()
    {
        return this.length * this.width * this.height;
    }
}

