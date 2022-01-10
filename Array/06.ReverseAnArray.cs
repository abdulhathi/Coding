using System;

public class ReverseAnArray {
    int[] arr = {8,3,9,15,6,10,7,2,12,4};
    public void Reverse() {
        for(int i = 0, j = arr.Length - 1; i < j; i++, j--) {
            arr[i] = arr[i] ^ arr[j];
            arr[j] = arr[i] ^ arr[j];
            arr[i] = arr[i] ^ arr[j];
        }
    }
    public void PrintArray() {
        Console.WriteLine(string.Join(",", arr));
    }
}