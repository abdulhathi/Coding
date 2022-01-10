using System;

public class LinearSearch {
    int[] arr = { 3, 7 ,12, 23, 56, 91, 2, 5, 6 };
    public void Search(int num) {
        for(int i = 0; i < arr.Length; i++) {
            if(arr[i] == num) {
                Console.WriteLine($"Element {num} found at an index {i}.");
                return;
            }
        }
        Console.WriteLine($"Element {num} is not found in the array.");
    }
}