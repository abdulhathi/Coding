using System;

public class Recursion {
    public static void PrintCallingTime() {
        CallingTime(3);
        Console.WriteLine();
    }
    private static void CallingTime(int n) {
        if(n > 0) {
            Console.Write(n+" ");
            CallingTime(n-1);
        }
    }

    public static void PrintReturnTime() {
        ReturnTime(3);
        Console.WriteLine();
    }
    private static void ReturnTime(int n) {
        if(n > 0) {
            ReturnTime(n-1);
            Console.Write(n+" ");
        }
    }
}