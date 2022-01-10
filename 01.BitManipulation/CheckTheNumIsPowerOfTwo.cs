using System;

public class CheckTheNumIsPowerOfTwo {
    public static void IsPowerOfTwo(int n) {
        if((n & 1) > 0)
            Console.WriteLine("This number is not power of 2");
        else
            Console.WriteLine("This number is power of 2");
    }
}