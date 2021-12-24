using System;

public class ValueTypeAndReferenceType {
    public static void ValTypeAndRefType() {
        // Value type scenario
        int a = -10;
        Console.WriteLine(a);
        ChangeValueType(a);
        Console.WriteLine(a);

        // Reference type scenario
        int[] arr = {-10};
        Console.WriteLine(arr[0]);
        ChangeReferenceType(arr);
        Console.WriteLine(arr[0]);

    }
    public static void ChangeValueType(int x) {
        x = 100;
    }
    public static void ChangeReferenceType(int[] x) {
        x[0] = 100;
    }
}