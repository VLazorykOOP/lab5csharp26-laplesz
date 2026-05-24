using System;

public sealed partial class Triangle
{

    private static partial bool IsValid(int a, int b, int c)
    {
        return (a + b > c) && (a + c > b) && (b + c > a) && (a > 0 && b > 0 && c > 0);
    }

    public partial int CalculatePerimeter()
    {
        return a + b + c;
    }

    public partial double CalculateArea()
    {
        double p = CalculatePerimeter() / 2.0;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public override string ToString()
    {
        return $"Color: {Color,-2} | Sides: ({a,2}, {b,2}, {c,2}) | Perimeter: {CalculatePerimeter(),3} | Area: {CalculateArea():F2}";
    }
}