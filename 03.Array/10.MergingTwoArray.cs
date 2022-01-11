using System;

public class MergingTwoArray {
    /*
        Time complexity : O(m+n) = O(n)
        Space complexisty : O(m+n) = O(n)
    */
    int[] arr1 = {3,8,16,20,25};
    int[] arr2 = {4,10,12,22,23};

    public void Merge() {
        int[] merged = new int[arr1.Length + arr2.Length];
        int i = 0, j = 0, k = 0;
        while(i < arr1.Length && j < arr2.Length) {
            if(arr1[i] < arr2[j])
                merged[k++] = arr1[i++];
            else
                merged[k++] = arr2[j++];
        }
        while(i < arr1.Length)
            merged[k++] = arr1[i++];
        while(j < arr2.Length)
            merged[k++] = arr2[j++];

        Console.WriteLine(string.Join(",", merged));
    }
}