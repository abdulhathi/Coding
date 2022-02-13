using System;
using System.Collections.Generic;

public class AllPossibleSubsets {
    public AllPossibleSubsets() {
        var combinations = Subsets(new int[] {1,2,3});
        foreach(var combination in combinations)
            Console.WriteLine(string.Join(",",combination));
    }
    public IList<IList<int>> Subsets(int[] nums) {
        List<IList<int>> combinations = new List<IList<int>>();
        List<int> current = new List<int>();
        
        DFS(0);
        return combinations;
        
        void DFS(int pos) {
            if(pos == nums.Length) {
                combinations.Add(current.ToList());
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