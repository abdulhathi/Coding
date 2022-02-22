using System;

public class TwosComplementOfANum {
    public TwosComplementOfANum() {
        Console.WriteLine(ConvertTo2sComplement(0));
    }
    public int ConvertTo2sComplement(int num) {
        return (~num) & 1;
    }
}