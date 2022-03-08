using System;

public class PerfectSquaresBUDP {
    public PerfectSquaresBUDP() {
        Console.WriteLine(BottomUp_Sqares(7));
    }
    public int BottomUp_Sqares(int n) {
        List<int> sqrts = new List<int>();
        int[] dp = Enumerable.Range(0, n+1).Select(x => int.MaxValue).ToArray();
        dp[0] = 0;

        for(int i = 1; i <= Math.Sqrt(n); i++) {
            sqrts.Add(i*i);
        }

        for(int i = 1; i <= n; i++) {
            for(int j = 0; j < Math.Floor(Math.Sqrt(i)); j++) {
                dp[i] = Math.Min(dp[i], dp[i - sqrts[j]]+1);
            }
        }
        // Console.WriteLine(string.Join(",",dp));
        return dp[n];
    }
}