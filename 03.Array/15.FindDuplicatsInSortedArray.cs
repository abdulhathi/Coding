using System;
using System.Collections.Generic;

public class FindDuplicatsInSortedArray {
    int[] arr = {3,6,8,8,10,12,15,15,15,20};
    public void FindDuplicates() {
        HashSet<int> hashSet = new HashSet<int>();
        HashSet<int> duplicates = new HashSet<int>();
        foreach(var num in arr) {
            if(hashSet.Contains(num))
                duplicates.Add(num);
            hashSet.Add(num);
        }
        Console.WriteLine(string.Join(",", duplicates));
    }
}