using System;

public class ModuloExponentiation {
    public ModuloExponentiation() {
        // Console.WriteLine(FastPower(2.00, 5));
        Console.WriteLine(FastPower(2.00, -5));
    }

    // Time: O(n), Space: O(1)
    public double Exponent(double m, int n) {
        if(n == 0)
            return 1.0;
        return Exponent(m, n-1) * m;
    }
    // Time: O(logN) Space: O(1)
    public double Exponent_LogNTime(double m, int n) { 
        if(n == 0)
            return 1.0;
        // Even
        if(n % 2 == 0)
            return Exponent_LogNTime(m*m, n/2);
        else
            return m * Exponent_LogNTime(m*m, (n-1)/2);
    }
    public double Exponent_NegativeNum(double m, int n) {
        if(n == 0)
            return 1.0;
        return Exponent_NegativeNum(m, n+1) / m;
    }
    public double FastPower(double m, int n) {
        long N = n;
        if(N < 0) {
            m = 1 / m;
            N = -N;
        }
        return FastPow(N);

        double FastPow(long newN) {
            if(newN == 0)
                return 1.0;
            double half = FastPow(newN/2);
            if(newN % 2 == 0)
                return half * half;
            else
                return half * half * m;
        }
    }
}