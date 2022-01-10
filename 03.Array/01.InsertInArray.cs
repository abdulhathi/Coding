using System;

public class InsertInArray {
    int[] arr = new int[10];
    public InsertInArray() {
        for(int i = 0; i < arr.Length; i++)
            arr[i] = -1;
    }
    public void Insert(int num) {
        int i = 0;
        while(arr[i] != -1)
            i++;
        arr[i] = num;
    }
    public void PrintArray() {
        Console.WriteLine(string.Join(",", arr));
    }
}