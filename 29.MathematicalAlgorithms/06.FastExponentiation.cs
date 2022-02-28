using System;

public class FastExponentiation {
    public FastExponentiation() {
        long result = FastExpo(5, 3, 100);
        Console.WriteLine(result);
    }
    // Time: O(logN) Space: O(1)
    public long FastExpo(long m, long n, long mod) {
        long power = 1;
        while(n > 0) {
            if((n & 1) == 1)
                power = (power * m) % mod;
            m = (m * m) % mod;
            n = n >> 1;
        }
        return power;
    }
}