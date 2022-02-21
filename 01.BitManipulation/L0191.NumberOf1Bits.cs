using System;

public class NumberOf1Bits {
    public NumberOf1Bits() {
        int count = HammingWeight(0b_11111111111111111111111111111101);
        Console.WriteLine(count);
    }
    public int HammingWeight(uint n) {
        int count = 0;
        while(n > 0) {
            n = n & n-1;
            count++;
        }
        return count;
    }
}