using System;

public class IndirectRecursion {
    public static void FuncA(int n) {
        if(n > 0) {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(n+" ");
            FuncB(n-1);
        }
    }
    public static void FuncB(int n) {
        if(n > 1) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(n+" ");
            FuncA(n/2);
        }
    }
}