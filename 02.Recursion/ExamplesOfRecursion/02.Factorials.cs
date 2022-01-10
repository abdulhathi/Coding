using System;

public class Factorials {
    // 5! = 1 * 2 * 3 * 4 * 5 = 120
    // 5! = 5 * 4 * 3 * 2 * 1 = 120
    public static int FindFactorial_Recursive(int n) {
        if(n == 0)
            return 1;
        return FindFactorial_Recursive(n-1) * n;
    }

    public static int FindFactorial_Iterative(int n) {
        int factorial = 1;
        for(int i = n; i >= 1; i--)
            factorial *= i;
        return factorial;
    }
}