using System;
using System.Collections.Generic;

public class LongestIncreasingSubSeqByNLogNTime {
    public LongestIncreasingSubSeqByNLogNTime() {
        // var input = new List<int>{2,3,7,8,10,13};
        // int key = BinarySearch(input, 14);
        // Console.WriteLine(input[key]);
        var subsequence = LongestIncreasingSubSequence(new int[] {2,5,3,7,11,8,10,13,6});
        Console.WriteLine(string.Join(",", subsequence));
    }
    public int[] LongestIncreasingSubSequence(int[] nums) {
        List<int> lowValue = new List<int>() {0};
        int[] parentMap = new int[nums.Length];
        parentMap[0] = -1;
        
        int i = 1, j = 0; 
        while(i < nums.Length) {
            parentMap[i] = -1;
            if(nums[i] > nums[lowValue[j]]) {
                parentMap[i] = lowValue[j];
                lowValue.Add(i);
            }
            else {
                var pos = BinarySearch(nums[i]);
                lowValue[pos] = i;
                parentMap[i] = lowValue[pos - 1];
            }
            i++; j = lowValue.Count - 1;
        }
        
        int[] result = new int[lowValue.Count];
        int seq = lowValue[j];
        while(seq != -1) {
            result[j--] = nums[seq];
            seq = parentMap[seq];
        }
        return result;

        int BinarySearch(int key) {
            int l = 0, r = lowValue.Count - 1;
            int mid = 0;
            while(l <= r) {
                mid = (l+r)/2;
                if(key > nums[lowValue[mid]])
                    l = mid+1;
                else
                    r = mid-1;
            }
            if(mid+1 < lowValue.Count)
                return nums[lowValue[mid+1]] >= key && nums[lowValue[mid]] < key ? mid+1 : mid;
            return mid;
        }
    }
}