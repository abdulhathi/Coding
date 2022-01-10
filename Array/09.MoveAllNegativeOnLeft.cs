using System;

public class MoveAllNegativeOnLeft {
    int[] arr = { -6,3,-8,10,5,-7,-9,12,-4,2 };
    
    public void MoveAllNegativeToLeftAndPostiveToRight() {
        int i = 0, j = arr.Length - 1;
        while(i < j) {
            while(arr[i] < 0) i++;
            while(arr[j] >= 0) j--;

            if(i < j)
            {
                arr[i] = arr[i] ^ arr[j];
                arr[j] = arr[i] ^ arr[j];
                arr[i] = arr[i] ^ arr[j];
            }
        }
    }
    public void PrintArray() {
        Console.WriteLine(string.Join(",", arr));
    }
}