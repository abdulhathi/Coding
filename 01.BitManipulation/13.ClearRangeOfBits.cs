using System;

public class ClearRangeOfBits {
    public ClearRangeOfBits() {
        Console.WriteLine(ClearRangeOfBitsInNum(245, 1, 6));
    }
    public int ClearRangeOfBitsInNum(int num, int i, int j) {
        /*
            11000011 = (11000000 | 00000011)
        */
        int a = (~(0)) << j+1;
        int b = (1 << i) - 1;
        int mask = a | b;
        num = num & mask;
        return num;
    }
}