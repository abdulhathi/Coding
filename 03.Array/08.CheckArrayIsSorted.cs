using System;

public class ArrayIsSorted {
    int[] arr = { 4,8,13,16,20,25,28,1 };
    public bool CheckArrayIsSorted() {
        for(int i = 1; i < arr.Length; i++)
            if(arr[i-1] > arr[i])
                return false;
        return true;
    }
}