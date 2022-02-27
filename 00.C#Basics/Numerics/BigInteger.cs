using System;
using System.Numerics;

public class BigIntegerTest {
    public BigIntegerTest() {
        BigInteger bigInt = BigInteger.Parse("1011");
        Console.WriteLine(Convert.ToInt32("1011", 2));

        Console.Write("BigInteger Addition : ");
        BigInteger sumBigInt = BigIntegerAdd();
        Console.WriteLine(sumBigInt);

        Console.Write("BigInteger bit length : ");
        BigInteger bitLength = GetBigIntegerBitLength(sumBigInt);
        Console.WriteLine(bitLength);

        Console.Write("BigInteger pow of 10 : ");
        PrintBigIntegerPow();

        Console.Write("BigInteger Greatest common divisor : ");
        BigInteger gcd = GreatestCommonDivisor();
        Console.WriteLine(gcd);

        Console.Write("BigInteger from Array : ");
        BigInteger bigIntFromArray = ArrayInputForBigInt(new int[] { 1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8,9 });
        Console.WriteLine(bigIntFromArray);
    }

    public BigInteger BigIntegerAdd() {
        string num1 = "2342342123123234234232123224234234";
        string num2 = "5";

        BigInteger bigInt1 = BigInteger.Parse(num1), bigInt2 = BigInteger.Parse(num2);
        BigInteger sum = BigInteger.Add(bigInt1, bigInt2);

        return sum;
    }

    public long GetBigIntegerBitLength(BigInteger bigInt) {
        return bigInt.GetBitLength();
    }

    public void PrintBigIntegerPow() {
        BigInteger numericBase = 3040506;
        for(int i = 10; i <= 10; i++)
            Console.WriteLine(BigInteger.Pow(numericBase, i));
    }

    public BigInteger GreatestCommonDivisor() {
        return BigInteger.GreatestCommonDivisor(56,56);
    }

    public BigInteger ArrayInputForBigInt(int[] arr) {
        BigInteger bigIntFromArray = 0;
        foreach(var num in arr) {
            bigIntFromArray = BigInteger.Multiply(bigIntFromArray, 10);
            bigIntFromArray = BigInteger.Add(bigIntFromArray, num);
        }
        return bigIntFromArray;
    }
}