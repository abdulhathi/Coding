using System;

public class TurnOffRightMostSetBit {
    public static void SetRightMostBitOff(int n) {
        n = (n & (n-1));
        Console.WriteLine(n);
    }
}