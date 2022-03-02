using System;

public class FindMinAndMaxInAnArray {
    public FindMinAndMaxInAnArray() {
        int[] arr = {5,8,3,9,6,2,10,7,-1,4};
        FindMinAndMaxInASingleScan(arr);
    }
    // Time O(n) and space O(1)
    public void FindMinAndMaxInASingleScan(int[] arr) {
        int min = arr[0], max = arr[0];
        for(int i = 1; i < arr.Length; i++) {
            if(arr[i] < min)
                min = arr[i];
            if(arr[i] > max)
                max = arr[i]; 
        }
        Console.WriteLine($"Min : {min} and Max : {max}");
    }
}