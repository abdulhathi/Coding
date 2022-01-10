using System;

public class CheckKTHBitIsOnOrOff {
    public static void CheckKTHBitStatus(int n, int k) {
        int num = 1 << (k-1);
        if((n & num) > 0)
            Console.WriteLine($"{k} th bit is set for the number : {n}");
        else
            Console.WriteLine($"{k} th bit is not set for the number : {n}");
    }
}