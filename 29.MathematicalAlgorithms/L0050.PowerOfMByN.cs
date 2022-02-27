using System;

public class L0050PowerOfMByN {
    public L0050PowerOfMByN() {
        // Console.WriteLine(MyPow(2.0, 10));
        Console.WriteLine(MyPow_Iterative(2.0, -0));
    }
    
    public double MyPow_Iterative(double x, int n) {
        return n < 0 ? MyPowNegative() : MyPowPositive();

        double MyPowNegative() {
            double divident = x;
            for(int i = 0; i > n; i--) {
                divident *= x;
            }
            return x / divident;
        }
        double MyPowPositive() {
            double ans = 1;
            for(int i = n; i > 0; i--)
                ans *= x;
            return ans;
        }
    }
}