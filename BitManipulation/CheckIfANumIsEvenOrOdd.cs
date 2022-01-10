using System;

public class EvenOrOdd {
    public static void CheckTheNumIsEvenOrOdd(int num) {
        if((num & 1) > 0) {
            Console.WriteLine("The num is Odd");
        }
        else
            Console.WriteLine("The num is Even");
    }
}