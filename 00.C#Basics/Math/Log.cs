using System;

public class Log {
    public Log() {
        CheckTheNumer_Is_PowerOfTwo();
        CheckTheNumber_Is_PowerOfThree();
    }

    public void CheckTheNumer_Is_PowerOfTwo() {
        Console.WriteLine("Log base 2 of the {0} Floor value {1} and Ceiling {2}"
        , 6, Math.Floor(Math.Log(8,2)), Math.Ceiling(Math.Log(8,2)));
    }

    public void CheckTheNumber_Is_PowerOfThree() {
        Console.WriteLine(Math.Log(243,3));
        Console.WriteLine("Log base 3 of the {0} Floor value {1} and Ceiling {2}"
        , 243, Math.Floor(Math.Log(243,3)), Math.Ceiling(Math.Log(243,3)));
    }
}