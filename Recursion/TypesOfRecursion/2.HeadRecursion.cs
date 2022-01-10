using System;

public class HeadRecursion {
    public void Recursive_HeadRecursion(int n) {
        if(n > 0) {
            Recursive_HeadRecursion(n-1);
            Console.Write(n+" ");
        }
    }
    public void Iterative_HeadRecursion(int n) {
        int i = 1;
        while(i <= n) {
            Console.Write(i+" ");
            i++;
        }
    }
}