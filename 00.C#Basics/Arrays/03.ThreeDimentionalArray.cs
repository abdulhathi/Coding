using System;

public class ThreeDimentionalArray {
    public ThreeDimentionalArray() {
        int[,,] threeDArray = { { {1,2,3,4},{5,6,7,8} },{ {9,10,11,12},{13,14,15,16} } };
        Console.WriteLine();
        Console.WriteLine($"GetLength(0) : {threeDArray.GetLength(0)}");
        Console.WriteLine($"GetLength(1) : {threeDArray.GetLength(1)}");
        Console.WriteLine($"GetLength(2) : {threeDArray.GetLength(2)}");
    }
}