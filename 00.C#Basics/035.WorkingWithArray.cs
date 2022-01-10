using System;

public class WorkingWithArray
{
    public static void ReadAndWriteInArray()
    {
        int size = Convert.ToInt32(Console.In.ReadLine());
        int[] array = new int[size];
        for (int i = 0; i < array.Length; i++) {
            array[i] = Convert.ToInt32(Console.In.ReadLine());
        }
        for (int i = 0; i < array.Length; i++) {
            Console.WriteLine(array[i]);
        }
    }
}