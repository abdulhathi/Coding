using System;

public class BinaryExponentiation {
    public BinaryExponentiation() {
        // Console.WriteLine(FastPower(2.00, 5));
        Console.WriteLine(BinaryExpo(2.00, -5));
    }
    public double BinaryExpo(double m, long n) {
        if(n < 0) {
            m = 1 / m;
            n = -n;
        }
        double power = 1.0;
        while(n > 0) {
            if((n & 1) > 0)
                power *= m;
            m *= m;
            n >>= 1;
        }
        return power;
    }
}