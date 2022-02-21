using System;

public class TurnOffRightMostSetBit {
    public static void SetRightMostBitOff(int n) {
        /*
            n = 20
            n       0001 0100
            n-1     0000 1111
        */
        n = (n & (n-1));
        Console.WriteLine(n);
    }
}