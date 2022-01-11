using System;

public class FindMissingElements {
    int[] arr = {6,7,9,10,13,15};

    public void PrintMissingNums() {
        int start = arr[0];
        for(int i = 1; i < arr.Length; i++)
            while(arr[i] > ++start)
                Console.Write(start+" ");
    }
}