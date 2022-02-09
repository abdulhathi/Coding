using System;

public class TwoDimentionalArray {
    public TwoDimentionalArray() {
        int[,] twoDArray = { {1,2,3,4},{5,6,7,8} };
        Console.WriteLine();
        Console.WriteLine($"GetLength(0) : {twoDArray.GetLength(0)}");
        Console.WriteLine($"GetLength(1) : {twoDArray.GetLength(1)}");
    }

}