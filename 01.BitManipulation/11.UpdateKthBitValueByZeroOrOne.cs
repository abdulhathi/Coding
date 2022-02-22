using System;

public class UpdateKthBitValueByZeroOrOne {
    public UpdateKthBitValueByZeroOrOne() {
        Console.WriteLine(UpdateKthBit(26,5,1));
    }
    public int UpdateKthBit(int num, int i, int val) {
        int mask = (val << i);
        return num | mask;
    }
}