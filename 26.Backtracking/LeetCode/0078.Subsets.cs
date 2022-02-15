/*
    Given an integer array nums of unique elements, return all possible subsets (the power set).
    The solution set must not contain duplicate subsets. Return the solution in any order.

    Example 1:
        Input: nums = [1,2,3]
        Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]
    Example 2:
        Input: nums = [0]
        Output: [[],[0]]
    
    Constraints:
        1 <= nums.length <= 10
        -10 <= nums[i] <= 10
        All the numbers of nums are unique.
        
    https://leetcode.com/problems/subsets/
*/
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