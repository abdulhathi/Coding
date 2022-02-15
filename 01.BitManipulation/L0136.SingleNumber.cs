// https://leetcode.com/problems/single-number/

using System;

public class SingleNumber {
    public SingleNumber() {
        Console.WriteLine(FindSingleNumber(new int[] {2,2,1}));
    }
    public int FindSingleNumber(int[] nums) {
        int singleOne = nums[0];
        for(int i = 1; i < nums.Length; i++) {
            singleOne ^= nums[i];
        }
        return singleOne;
    }
}