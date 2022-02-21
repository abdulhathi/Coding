using System;

public class ToggleTheKTHBit {
    public ToggleTheKTHBit() {
        ToggleKTHBit(8,3);
    }
    
    public static void ToggleKTHBit(int n, int k) {
        /*
            n = 8 (0000 1000) , k = 3
            num = 1

            num         0000 0001
            n           0000 1000
            num << k    0000 0100 (OR)
            ----------------------
            n | num     0000 1100
        */

        int num = 1 << (k-1);
        n = n ^ num;

        Console.WriteLine(n);
    }
}