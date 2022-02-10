using System;

public class BestTimeToBuyAndSellStock {
    public BestTimeToBuyAndSellStock() {
        Console.WriteLine("Brute force method result           : {0}",MaxProfit(new int[] {7,6,4,3,1}));
        Console.WriteLine("Dynamic programming method result   : {0}",MaxProfit_DP(new int[] {7,1,5,3,6,4}));
    }

    // Brute force approach
    // Time : O(n^2), Space : O(1)
    public int MaxProfit(int[] prices) {
        int maxProfit = 0;
        for(int i = 0; i < prices.Length; i++)
            for(int j = i + 1; j < prices.Length; j++)
                maxProfit = Math.Max(maxProfit, prices[j] - prices[i]);
        return maxProfit;
    }

    // Dynamic programming
    public int MaxProfit_DP(int[] prices) {
        if(prices == null || prices.Length == 0)
            return 0;
        int minBuy = prices[0], maxProfit = 0;
        for(int i = 1; i < prices.Length; i++) {
            if(prices[i] < minBuy) 
                minBuy = prices[i];
            maxProfit = Math.Max(maxProfit, prices[i] - minBuy);
        }
        return maxProfit;
    }
}