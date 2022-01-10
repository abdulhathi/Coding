using System;

public class SumOfNNaturalNums {
    public static int Sum(int n) {
        if(n == 0)
            return 0;
        else
            return Sum(n-1)+n;
    }
}