using System;
using System.Collections.Generic;

public class SubsetsII {
    public SubsetsII() {
        var combinations = SubsetsWithDup(new int[] {1,2,2});
        foreach(var combination in combinations)
            Console.WriteLine(string.Join(",",combination));
    }
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        nums = nums.OrderBy(n=>n).ToArray();
        List<IList<int>> combinations = new List<IList<int>>();
        List<int> current = new List<int>();
        HashSet<string> memoization = new HashSet<string>();
        
        DFS(0);
        return combinations;
        
        void DFS(int pos) {
            if(pos == nums.Length) {
                var currStr = string.Join(",",current);
                if(!memoization.Contains(currStr)) {
                    combinations.Add(current.ToList());
                    memoization.Add(currStr);
                }
            }
            else {
                current.Add(nums[pos]);
                DFS(pos+1);
                current.RemoveAt(current.Count-1);
                DFS(pos+1);
            }
        }
    }
}