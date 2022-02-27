using System;

public class BitwiseANDOfNumbersRange {
    public BitwiseANDOfNumbersRange() {
        // int bitwiseAndResult = RangeBitwiseAnd(700000000,2147483641);
        int bitwiseAndResult = RangeBitwiseAnd(9,12);
        Console.WriteLine(bitwiseAndResult);
    }
    public int RangeBitwiseAnd(int left, int right) {
        int count = 0;
        while(left < right) {
            left = left >> 1;
            right = right >> 1;
            count++;
        }
        return left << count;
    }
}