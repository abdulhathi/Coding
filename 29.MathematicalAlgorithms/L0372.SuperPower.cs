using System;
using System.Numerics;

public class SuperPower {
    public SuperPower() {
        int a = 223231423;
        int[] b = {4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5,2,3,3,8,5,2,4,3,3,8,5,2,4,3,3,8,5};
        Console.WriteLine(SuperPow(a, b));
    }
    public int SuperPow(int a, int[] b) {
        BigInteger bigIntA = a;
        BigInteger bigIntB = 0;
        BigInteger bigIntTwo = BigInteger.One + BigInteger.One;
        foreach(int num in b) {
            bigIntB = BigInteger.Multiply(bigIntB, 10);
            bigIntB = BigInteger.Add(bigIntB, num);
        }
        
        return (int)FastPower(bigIntA, bigIntB) % 1337;
        
        BigInteger FastPower(BigInteger bigA, BigInteger n) {
            if(n == 0)
                return BigInteger.One;
            var half = FastPower(bigA, BigInteger.Divide(n,2));
            if(n % bigIntTwo == 0)
                return (half * half) % 1337;
            else
                return (half * half * bigA) % 1337;
        }
    }
}