using System;

public class LongestIncreasingSubsequence {
    public LongestIncreasingSubsequence() {
        int maxLength = LIS_BottomUp(new int[] {3,4,-1,0,6,2,3});
        Console.WriteLine($"Maximum length of increasing subsequence : {maxLength}");
    }

    /* Tabulation iterative method
        Index   0 1  2 3 4 5 6
        Value   3 4 -1 0 6 2 3
        LIS     1 2  1 2 3 3 4
        ParentM N 0  N 2 1 3 5
    */
    public int LIS_BottomUp(int[] arr) {
        int[] lengthTable = new int[arr.Length];
        int?[] parentMap = new int?[arr.Length];
        Stack<int> LISStack = new Stack<int>();
        for(int i = 0; i < arr.Length; i++)
            lengthTable[i] = 1;
        int max = 1, maxValIndex = 0;
        for(int i = 1; i < arr.Length; i++) {
            for(int j = 0; j < i; j++) {
                if(arr[i] > arr[j]) {
                    if(lengthTable[i] < lengthTable[j] + 1) {
                        max = lengthTable[i] = lengthTable[j] + 1;
                        parentMap[i] = j;
                        maxValIndex = i;
                    }
                }
            }
        }
        while(parentMap[maxValIndex] != null) {
            LISStack.Push(arr[maxValIndex]);
            maxValIndex = parentMap[maxValIndex].Value;
        }
        LISStack.Push(arr[maxValIndex]);
        Console.Write("[");
        while(LISStack.Count > 0)
            Console.Write(LISStack.Pop()+",");
        Console.WriteLine("]");
        return max;
    }
}