using System;

public class ReplaceNumMWithNInGivenRange {
    public ReplaceNumMWithNInGivenRange() {
        Console.WriteLine(ReplaceBit(128, 21, 2,6));
    }
    public int ReplaceBit(int M, int N, int i, int j) {
        N = N << i;
        return M | N;
    }
}