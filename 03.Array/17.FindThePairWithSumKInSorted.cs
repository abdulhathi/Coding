using System;

public class FindThePairWithSumKInSorted {
    int[] arr = {1,3,4,5,5,6,8,9,10,12,14};
    public FindThePairWithSumKInSorted() {
        FindThePairInSorted(10);
    }
    // Time O(n), Space O(1)
    public void FindThePairInSorted(int k) {
        int i = 0, j = arr.Length - 1;
        while(i < j) {
            if(arr[i]+arr[j] > k)
                j--;
            else if(arr[i]+arr[j] < k)
                i++;
            else
                Console.WriteLine($"Pair found {arr[i++]},{arr[j--]}");
        }
    }
}