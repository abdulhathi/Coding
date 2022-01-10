using System;

public class StringDataType
{
    public static void StringBasics()
    {
        // string concatenation
        string name = "Abdul";
        string name1 = name;
        name += " Hathi";
        Console.WriteLine(name);

        // string interpolation
        string str = $"Hi my name  is {name}";
        Console.WriteLine(str);
    }

}