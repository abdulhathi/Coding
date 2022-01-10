using System;

public class ToggleTheKTHBit {
    public static void ToggleKTHBit(int n, int k) {
        /*
            n = 8 (0000 1000)
            k = 0000 0001 << 3 = 0000 0100
            XOR of n and K =  0000 1000 ^
                              0000 0100  
                              ---------
                              0000 1100 
        */

        int num = 1 << (k-1);
        n = n ^ num;

        Console.WriteLine(n);
    }
}