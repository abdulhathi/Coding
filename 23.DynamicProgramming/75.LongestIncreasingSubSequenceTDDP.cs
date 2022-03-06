using System;

public class LongestIncreasingSubSequenceTDDP {
    public LongestIncreasingSubSequenceTDDP() {
        int[] arr = {50, 4, 10, 8, 30, 100};
        Console.WriteLine(TopDown_LIS(arr));
    }
    public int TopDown_LIS(int[] arr) {
        int[] memory = new int[arr.Length];
        TopDown(arr.Length - 1, int.MaxValue);
        int max = int.MinValue;
        foreach(var count in memory)
            max = Math.Max(count, max);
        return max;

        int TopDown(int p, int root) {
            if(arr[p] > root)
                return 0;
            if(p == 0)
                return 1;
            
            if(memory[p] != 0)
                return memory[p];
                
            for(int i = p-1; i >= 0; i--) {
                if(memory[i] == 0)
                    memory[i] = TopDown(i, arr[p]);
                memory[p] = Math.Max(memory[p], memory[i] + 1);
            }
            return memory[p];
        }
    }
}