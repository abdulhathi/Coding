/* https://leetcode.com/problems/two-sum/
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order.
*/
using System;
using System.Collections.Generic;

public class TwoSumTest {
    public TwoSumTest() {
        int[] validPairs = TwoSum(new int[] {2,7,2,11,15}, 9); 
        Console.WriteLine(string.Join(",", validPairs));
    }
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> pair = new Dictionary<int, int>();
        var validPairs = new HashSet<int>();
        int diff = 0;
        for(int i = 0; i < nums.Length; i++) {
            diff = target - nums[i];
            if(pair.ContainsKey(diff)) {
                validPairs.Add(pair[diff]);
                validPairs.Add(i);
            }
            if(!pair.ContainsKey(nums[i]))
                pair.Add(nums[i], i);
        }
        return validPairs.ToArray();
    }
}