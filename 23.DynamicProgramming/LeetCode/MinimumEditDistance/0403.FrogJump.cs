public class FrogJump {
    public FrogJump() {
        int[] stones = {0,1,2,3,4,8,9,11}; //{0,1,2,5,6,9,10,12,13,14,17,19,20,21,26,27,28,29,30};
        Console.WriteLine(CanCross(stones));
    }
    public bool CanCross(int[] stones) {
        int n = stones.Length;
        var dp = new Dictionary<int, Dictionary<int, bool>>();
        for(int i = 0; i < n; i++)
            dp.Add(stones[i], new Dictionary<int, bool>());

        return TopDown(0, 0);

        bool TopDown(int stone, int unit) {
            if(!dp.ContainsKey(stone))
                return false;
            if(stone == stones[n-1])
                return true;

            for(int i = 1; i >= -1; i--) {
                int nextUnit = unit+i, nextStone = stone+nextUnit;
                if(!dp[stone].ContainsKey(nextStone)) {
                    dp[stone].Add(nextStone,false);
                    dp[stone][nextStone] = TopDown(nextStone, nextUnit);
                }
                if(dp[stone][nextStone])
                    return true;
            }
            return false;
        }
    }
}