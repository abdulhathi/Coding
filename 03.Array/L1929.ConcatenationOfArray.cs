/*  https://leetcode.com/problems/concatenation-of-array/
    Given an integer array nums of length n, you want to create an array ans of length 2n where ans[i] == nums[i] and ans[i + n] == nums[i] for 0 <= i < n (0-indexed).
    Specifically, ans is the concatenation of two nums arrays.
    Return the array ans.
*/
public class ConcatenationOfArray {
 public ConcatenationOfArray() {
     var ans = GetConcatenation(new int[] {1,3,2,1});
     Console.WriteLine(string.Join(",",ans));
 }
 public int[] GetConcatenation(int[] nums) {
        int n = nums.Length;
        int[] ans = new int[n*2];
        for(int i = 0;i < n; i++) {
            ans[i] = ans[i+n] = nums[i];
        }
        return ans;
    }
}