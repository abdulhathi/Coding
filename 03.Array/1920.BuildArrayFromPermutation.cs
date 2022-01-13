using System;

public class BuildArrayFromPermutation {
    public BuildArrayFromPermutation() {
        int[] nums = {0,2,1,5,3,4};
        int[] result = BuildArray(nums);
        Console.WriteLine(string.Join(",", result));
    }
    public int[] BuildArray(int[] nums) {
        int[] ans = new int[nums.Length];
        for(int i = 0; i < nums.Length; i++) {
            ans[i] = nums[nums[i]];
        }
        return ans;
    }
}