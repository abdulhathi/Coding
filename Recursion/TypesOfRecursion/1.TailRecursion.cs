using System;

public class TailRecursion {

    // Time Complexity  : O(n)
    // Space Complexity : O(n) - n activation records will create on the memory stack
    public void Recursive_TailFunc(int n) {
        if(n > 0) {
            Console.Write(n+" ");
            Recursive_TailFunc(n-1);
        }
    }

    // Time Complexity  : O(n)
    // Space Complexity : O(1)
    public void Iterative_TailFunc(int n) {
        while(n > 0) {
            Console.Write(n+" ");
            n--;
        }
    }
}