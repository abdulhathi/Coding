using System;
using System.Collections.Generic;
using System.Numerics;

public class LargeFactorial {
    public LargeFactorial() {
        int num = 100;
        int[] output = FindLargeFactorial(num);
        Console.WriteLine(string.Join("",output.Reverse()));

        BigInteger factorial = Factorial(num);
        Console.WriteLine(factorial);
    }
    // Array result
    public int[] FindLargeFactorial(int num) {
        if(num <= 1)
            return new int[] {num};
        int[] prev = FindLargeFactorial(num - 1);
        int total = 0, carry = 0;
        List<int> result = new List<int>();
        for(int i = 0; i < prev.Length; i++) {
            total = prev[i] * num + carry;
            result.Add(total % 10);
            carry = total / 10;
        }
        while(carry > 0) {
            result.Add(carry % 10);
            carry /= 10; 
        }
        return result.ToArray();
    }

    // BigInteger result
    public BigInteger Factorial(int num) {
        BigInteger product = BigInteger.One;
        for(int i = 2; i <= num; i++)
            product = BigInteger.Multiply(product, i);
        return product;
    }
}