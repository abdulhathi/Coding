using System;

public class UpdateKthBitValueByZeroOrOne {
    public UpdateKthBitValueByZeroOrOne() {
        Console.WriteLine(UpdateKthBit(26,5,1));
    }
    /*       7 6 5 4 3 2 1 0
        26 - 0 0 0 1 0 1 0 0
        58 - 0 0 1 1 0 1 0 0
    */
    public int UpdateKthBit(int num, int i, int val) {
        int mask = (val << i);
        return num | mask;
    }
}