using System;
using System.Collections.Generic;

public class InsertAnElement {
    int[] arr = { 4,8,13,16,20,25,28,33, -1, -1 };
    public void InsertInSortedArray(int num) {
        int i = 7;
        while(num < arr[i])
        {
            arr[i+1] = arr[i];
            i--;
        }
        arr[i+1] = num;
    }
    public void PrintArray() {
        Console.WriteLine(string.Join(",", arr));
    }
}