using System;

public class TurnOnKTHBit {
    public static void TurnOnKTHBitInANum(int n, int k) {
        /*
            n = 20 (0001 0100)
            k = 4
            num = 1 (0000 0001)
            k = k - 1 = 3
            num << k = (0000 0001) << 3 = (0000 1000)
            n & num  = 0001 0100 |
                       0000 1000  
                      -----------
                       0001 1100 (28)
        */
        // Step 1 : k - 1
        k = k - 1;
        
        // Step 2 : 1 << k
        int num = 1 << k;

        // Step 3 : n | num
        n = n | num;

        Console.WriteLine(n);
    }
}