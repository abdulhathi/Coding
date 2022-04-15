// Multiplicative Modulo Inverse (MMI)

public class MultiplicativeModInverse {
    public MultiplicativeModInverse() {
        int mmi = ModInverse(2,7);
        Console.WriteLine(mmi);
    }
    public int ModInverse(int a, int m) {
        var gcd = ExtendedEuclids.FindXYGCD(a, m);
        if(gcd.GCD != 1)
            return -1;
        return gcd.X < 0 ? (gcd.X%m + m)%m : gcd.X;
    }
}