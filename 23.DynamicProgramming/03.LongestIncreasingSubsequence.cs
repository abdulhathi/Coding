using System;

public class LongestIncreasingSubsequence {
    public LongestIncreasingSubsequence() {
        Console.WriteLine(LIC_BottomUp(new int[] {3,4,-1,0,6,2,3}));
    }

    // Tabulation iterative method
    public int LIC_BottomUp(int[] arr) {
        int[] lengthTable = new int[arr.Length];
        for(int i = 0; i < arr.Length; i++)
            lengthTable[i] = 1;
        int max = 1;
        for(int i = 1; i < arr.Length; i++) {
            for(int j = 0; j < i; j++) {
                if(arr[i] > arr[j]) {
                    max = lengthTable[i] = Math.Max(lengthTable[i], lengthTable[j] + 1);
                }
            }
        }
        return max;
    }
}