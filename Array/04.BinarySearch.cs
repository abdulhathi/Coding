using System;

public class BinarySearch {
    int[] arr = { 4,8,10,15,18,21,24,27,29,33,34,37,39,41,43 };
    
    public int IterativeBinarySearch(int key) {
        int low = 0, high = arr.Length - 1, mid = 0;
        while(low <= high) {
            mid = (low+high) / 2;
            if(arr[mid] == key)
                return mid;
            else if(key < arr[mid])
                high = mid - 1;
            else
                low = mid + 1;
        }
        return -1;
    }
    public int RecursiveBinarySearch(int key) {
        return RecursiveBinarySearch(0, arr.Length - 1, key);
    }
    public int RecursiveBinarySearch(int low, int high, int key) {
        if(low <= high) {
            int mid = (low + high) / 2;
            if(arr[mid] == key)
                return mid;
            else if(key < arr[mid])
                return RecursiveBinarySearch(low, mid - 1, key);
            else
                return RecursiveBinarySearch(mid + 1, high, key);
        }
        return -1;
    }
}