using System;

public class StringDataType
{
    public StringDataType() {
        StringBasics();
    }
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

        string nums = "01234";
        for(int i =0; i < (int)(nums[3]-'0'); i++)
            Console.Write(i+",");
    }

}