using System;

public class CoinChangeNumOfWays {
    public CoinChangeNumOfWays() {
        Console.WriteLine(NumberOfWaysToGetSum(6, new int[] {2,5,3,6}));
        Console.WriteLine(NumberOfWaysToGetSum(4, new int[] {1,2,3}));
    }
    public int NumberOfWaysToGetSum(int sum, int[] coins) {
        int rowLength = coins.Length + 1, colLength = sum + 1;
        int[,] tabulation = new int[rowLength,colLength];
        for(int r = 0; r < rowLength; r++)
            tabulation[r,0] = 1;

        for(int r = 1; r < rowLength; r++) {
            for(int c = 1; c < colLength; c++) {
                if(coins[r-1] > c)
                    tabulation[r,c] = tabulation[r-1,c];
                else
                    tabulation[r,c] = tabulation[r-1,c] + (tabulation[r, c - coins[r-1]]);
            }
        }
        return tabulation[rowLength-1,colLength-1];
    }
}