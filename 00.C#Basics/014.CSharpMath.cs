using System;

public class CSharpMath
{
    public static void MathPractice()
    {
        int x = -10;
        Console.WriteLine(Math.Abs(x));
        double d = 5.5;
        Console.WriteLine(Math.Ceiling(d));
        Console.WriteLine(Math.Floor(d));

        Console.WriteLine(Math.Sign(x));
        int y = 10;
        Console.WriteLine(Math.Sign(y));
    }
}