using System;

public class TwoDimentionalArray {
    public TwoDimentionalArray() {
        int[,] twoDArray = { {1,2,3,4},{5,6,7,8} };
        Console.WriteLine();
        Console.WriteLine($"GetLength(0) Row length : {twoDArray.GetLength(0)}");
        Console.WriteLine($"GetLength(1) Column length : {twoDArray.GetLength(1)}");
    }

}