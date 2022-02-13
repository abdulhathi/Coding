using System;
using System.Collections.Generic;

public class ZeroOneKnapsackProblem {
    public ZeroOneKnapsackProblem() {
        int[] weight = {1,3,4,5}, profit = {1,4,5,7};
        int capacity = 7;
        int maxProfit = ZeroOneKnapsackToGetProfit(weight, profit, capacity);
        Console.WriteLine(maxProfit);

        weight = new int[] {2,2,4,5}; profit = new int[] {2,4,6,9}; capacity = 8;
        int max = ZeroOneKnapsack_BT_Memoization(weight, profit, capacity);
        Console.WriteLine(max);
    }
    public int ZeroOneKnapsackToGetProfit(int[] weight, int[] profit, int capacity) {
        int rowLen = weight.Length+1, colLen = capacity+1;
        int[,] tabulation = new int[rowLen,colLen];

        for(int r = 1; r < rowLen; r++) {
            for(int c = 1; c < colLen; c++) {
                if(weight[r-1] > c)
                    tabulation[r,c] = tabulation[r-1,c];
                else
                    tabulation[r,c] = Math.Max(tabulation[r-1,c], profit[r-1] + tabulation[r-1,c-weight[r-1]]);
            }
        }
        return tabulation[rowLen-1,colLen-1];
    }

    public int ZeroOneKnapsack_BackTracking(int[] weight, int[] profit, int totalCapacity) {
        return DFS(0, totalCapacity);

        int DFS(int pos, int capacity) {
            if(pos < weight.Length && capacity - weight[pos] >= 0) {
                int left = DFS(pos+1, capacity - weight[pos]) + profit[pos];
                int right = DFS(pos+1, capacity);
                return Math.Max(left, right);
            }
            return 0;
        }
    }
    
    public int ZeroOneKnapsack_BT_Memoization(int[] weight, int[] profit, int totalCapacity) {
        var parentMap = new Dictionary<(int Weight, int Remaining), int>();
        int n = weight.Length;
        return DFS(0, totalCapacity);

        int DFS(int pos, int capacity) {
            if(pos < weight.Length && capacity - weight[pos] >= 0) {
                if(parentMap.ContainsKey((capacity, n-pos)))
                    return parentMap[(capacity, n-pos)];
                else {
                    int left =  DFS(pos+1, capacity - weight[pos]) + profit[pos];
                    int right = DFS(pos+1, capacity);
                    int max = Math.Max(left, right);
                    parentMap.Add((capacity, n-pos), max);
                    return max;
                }
            }
            return 0;
        }
    }
}