using System;

public class TurnOffKTHBit {
    public static void TurnOffKathBitInANum(int n, int k) {
        /*
            Params  : n = 20, k = 3
            Declare : num = 1;
            num         0000 0001
            num << k-1  0000 0100
            ~num        1111 1011
            n           0001 0100
            num & n     0001 0000
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