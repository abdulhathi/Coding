using System;

public class ZeroOneKnapsackProblem {
    public ZeroOneKnapsackProblem() {
        int[] weight = {1,3,4,5}, profit = {1,4,5,7};
        int capacity = 7;
        int maxProfit = ZeroOneKnapsackToGetProfit(weight, profit, capacity);
        Console.WriteLine(maxProfit);
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
}