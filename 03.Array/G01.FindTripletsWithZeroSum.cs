using System;

public class FindTripletsWithZeroSum {
    public FindTripletsWithZeroSum() {
        var triplets = FindTriplets(new int[] {4, -16, 43, 4, 7, -36, 18}, 7);
        Console.WriteLine(triplets);
    }
    public bool FindTriplets(int[] arr, int n) {
        for(int i = 0; i < arr.Length; i++)
            if(TwoSumEqualsToK(arr, -arr[i], i))
                return true;
        return false;
    }
    public bool TwoSumEqualsToK(int[] arr, int k, int j) {
        HashSet<int> hashSet = new HashSet<int>();
        for(int i = 0; i < arr.Length; i++) {
            if(i == j)
                continue;
            if(hashSet.Contains(k-arr[i]))
                return true;
            hashSet.Add(arr[i]);
        }
        return false;
    }
}