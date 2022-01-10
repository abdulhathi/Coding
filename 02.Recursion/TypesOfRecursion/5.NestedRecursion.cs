using System;

public class NestedRecursion {
    public static int Func(int n) {
        if(n > 100) {
            Console.Write(n+ " ");
            return n - 10;
        }
        return Func(Func(n+11));
    }
}