using System;

public class GetSetSumAvgMax {
    int[] arr = {8,3,9,15,6,10,7,2,12,4};
    public int GetIndex(int key) {
        for(int i = 0; i < arr.Length; i++)
            if(arr[i] == key) {
                Console.WriteLine($"{key} found in index {i}");
                return i;
            }
        Console.WriteLine($"{key} not found in index");
        return -1;
    }

    public void SetIndex(int key, int index) {
        if(index >= 0 && index < arr.Length)
            arr[index] = key;
    }
    public int Sum() {
        int total = arr[0];
        for(int i = 1; i < arr.Length; i++)
            total += arr[i];
        return total;
    }
    public int Avg() {
        int total = arr[0];
        for(int i = 1; i < arr.Length; i++)
            total += arr[i];
        return total / arr.Length;
    }
    public int Max() {
        int max = arr[0];
        for(int i = 1; i < arr.Length; i++)
            if(max < arr[i]) 
                max = arr[i];
        return max;
    }
    public int Min() {
        int min = arr[0];
        for(int i = 1; i < arr.Length; i++)
            if(min > arr[i]) 
                min = arr[i];
        return min;
    }
    public void PrintArray() {
        Console.WriteLine(string.Join(",", arr));
    }
}