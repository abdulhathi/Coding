/*
    Girl A and B together has 10 apple. Girl B should have more than the apples are having by Girl A.
    Count how many number of apples have by Girl A and B if the total (N) and difference(K) given.
*/
using System;
using System.Numerics;

public class AppleCountProblem {
    public AppleCountProblem() {
        var appleCount = CountNumOfApples("100000000000000000000000","121212121212121212");
        Console.WriteLine(string.Join(",", appleCount));
    }
    public BigInteger[] CountNumOfApples(string n, string k) {
        BigInteger bigIntN = BigInteger.Parse(n), bigIntK = BigInteger.Parse(k);

        /*  A + B = N
            B = A + K
            A + (A + K) = N;
            2A + K = N;
            2A = (N - K);
            A = (N - K) / A;

            B = N - A;
        */
        BigInteger bigIntTwo = BigInteger.One + BigInteger.One;
        BigInteger girlAAppleCount = BigInteger.Divide(BigInteger.Subtract(bigIntN, bigIntK), bigIntTwo);
        BigInteger girlBAppleCount = BigInteger.Subtract(bigIntN, girlAAppleCount);
        return new BigInteger[] {girlBAppleCount, girlAAppleCount};
    }
}