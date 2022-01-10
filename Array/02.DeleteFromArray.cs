using System;

public class DeleteFromArray {
    int[] arr = { 1,2,3,4,5,6,7,8 };
    public void Delete(int index) {
        if(index < arr.Length) {
            arr[index] = -1;
            PrintArray();
        }
        else
            Console.WriteLine("index not found in the array");
    }
    public void PrintArray() {
        Console.WriteLine(string.Join(",", arr));
    }
}