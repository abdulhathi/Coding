using System;
using System.Collections.Generic;

public class UnionTwoArray {
    public UnionTwoArray() {
        Console.Write("Union un sorted array : ");
        UnionUnsortedArray();
        Console.Write("Union sorted array : ");
        UnionSortedArray();
    }
    // Time Complexity : O(m + (m*n)) => O(m+n^2) = > O(n^2)
    public void UnionUnsortedArray() {
        int[] arr1 = {3,5,10,4,6};
        int[] arr2 = {12,4,7,2,5};
        List<int> merged = new List<int>();
        foreach(var num in arr1) 
            merged.Add(num);
        foreach(var num in arr2) {
            if(!NumExist(num, merged))
                merged.Add(num);
        }
        Console.WriteLine(string.Join(",", merged));
    }
    public bool NumExist(int num, List<int> merged)
    {
        foreach(var num1 in merged)
            if(num1 == num)
                return true;
        return false;
    }

    public void UnionSortedArray() {
        int[] arr1 = {3,4,5,6,10};
        int[] arr2 = {2,4,5,7,12};
        List<int> merged = new List<int>();
        int i = 0, j = 0;
        while(i < arr1.Length && j < arr2.Length) {
            if(arr1[i] < arr2[j])
                merged.Add(arr1[i++]);
            else if(arr1[i] > arr2[j])
                merged.Add(arr2[j++]);
            else {
                merged.Add(arr1[i]);
                i++; j++;
            }
        }
        while(i < arr1.Length)
            merged.Add(arr1[i++]);
        while(j < arr2.Length)
            merged.Add(arr2[j++]);
        Console.WriteLine(string.Join(",",merged));
    }
}