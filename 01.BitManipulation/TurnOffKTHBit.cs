using System;

public class TurnOffKTHBit {
    public static void TurnOffKathBitInANum(int n, int k) {
        /*
                K = 3;
                k-1 = 2;
                1 << k 
                0001 << k -> 0100 
                ~0100 = 1011

                n = 20   0001 0100 &
                         1111 1011
                        ------------
                         0001 0000  = 16
        */

        // Step 1   (k-1)
        k = k - 1;

        // Step 2   1 << k
        int num = 1 << k;

        // Step 3   1s Complement of num (~num)
        num = ~num;

        // Step 4   & num with n
        n = n & num;

        // Step 5 print n;
        Console.WriteLine(n);
    }
}