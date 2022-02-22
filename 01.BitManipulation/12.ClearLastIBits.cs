using System;

public class ClearLastIBits {
    public ClearLastIBits() {
        // 237 remove last 5 bits (237 - 13) = 224
        Console.WriteLine(ClearLastBits(237, 5));
    }
    public int ClearLastBits(int num, int i) {
        int mask = (~(0)) << i;
        return num & mask;
    }
}