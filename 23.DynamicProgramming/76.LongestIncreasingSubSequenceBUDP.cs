using System;

public class LongestIncreasingSubSequenceBUDP {
    public LongestIncreasingSubSequenceBUDP() {
        int[] arr = {50, 4, 10, 8, 30, 100};
        Console.WriteLine(BottomUp_LIS(arr));
    }
    public int BottomUp_LIS(int[] arr) {
        int[] tabulation = Enumerable.Range(0, arr.Length).Select(x => 1).ToArray();

        for(int i = 1; i < arr.Length; i++) {
            for(int j = 0; j < i; j++) {
                if(arr[i] > arr[j])
                    tabulation[i] = Math.Max(tabulation[i], tabulation[j] + 1);
            }
        }
        
        int max = int.MinValue;
        for(int i = 0; i < arr.Length; i++) 
            max = Math.Max(tabulation[i], max);
        return max;
    }
}