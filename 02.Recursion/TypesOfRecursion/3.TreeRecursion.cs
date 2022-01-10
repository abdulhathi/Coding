using System;

public class TreeRecursion {
    public static void Recursive_TreeRecursion(int n) {
        if(n > 0) {
            Console.Write(n+" ");
            Recursive_TreeRecursion(n-1);
            Recursive_TreeRecursion(n-1);
        }
    }
}