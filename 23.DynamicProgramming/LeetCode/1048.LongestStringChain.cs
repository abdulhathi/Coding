public class LongestStringChain {
    public LongestStringChain() {
        string[] words = {"a","b","ba","bca"};
        Console.WriteLine(LongestStrChain(words));
    }
    public int LongestStrChain(string[] words) {
        var dp = new Dictionary<string, int>();
        foreach(var word in words)
            if(!dp.ContainsKey(word)) dp.Add(word, -1);

        int maxChainLen = 0;
        foreach(var word in words)
            maxChainLen = Math.Max(TopDown(word), maxChainLen);
        return maxChainLen;

        int TopDown(string word) {
            if(!dp.ContainsKey(word))
                return 0;
            if(dp[word] != -1)
                return dp[word];

            dp[word] = 1;
            int max = 0;
            for(int i = 0; i < word.Length; i++) {
                max = Math.Max(max, dp[word] + TopDown(word.Substring(0,i) + word.Substring(i+1)));
            }
            return dp[word] = max;
        }
    }
}