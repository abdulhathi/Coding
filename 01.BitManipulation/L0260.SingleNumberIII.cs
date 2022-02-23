/*                      260. Single Number III
    Given an integer array nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once. You can return the answer in any order.
    You must write an algorithm that runs in linear runtime complexity and uses only constant extra space.
    Example 1:
        Input: nums = [1,2,1,3,2,5]
        Output: [3,5]
        Explanation:  [5, 3] is also a valid answer.
    Example 2:
        Input: nums = [-1,0]
        Output: [-1,0]
    Example 3:
        Input: nums = [0,1]
        Output: [1,0]
    Constraints:
        2 <= nums.length <= 3 * 104
        -231 <= nums[i] <= 231 - 1
        Each integer in nums will appear twice, only two integers will appear once.
*/
using System;

public class SingleNumberIII {
    public SingleNumberIII() {
        var nums = new int[] {1,2,1,3,2,5};
        var uniqueNums = SingleNumber(nums);
        Console.WriteLine(string.Join(",",uniqueNums));
    }
    public int[] SingleNumber(int[] nums) {
        // XOR of all the numbers
        int XOROfAllNums = 0;
        foreach(var num in nums)
            XOROfAllNums ^= num;
        
        // First set bit check
        int firstSetBit = 1;
        for(int i = 0; i < 32; i++)
            if(((XOROfAllNums >> i) & 1) > 0) {
                firstSetBit = firstSetBit << i;
                break;
            }
        // XOR the nums have the & with firstSetBit to get > 0
        int[] oneTimeNums = new int[2];
        foreach(var num in nums)
            if((num & firstSetBit) > 0)
                oneTimeNums[0] ^= num;
        oneTimeNums[1] = oneTimeNums[0] ^ XOROfAllNums;
        return oneTimeNums;
    }
}