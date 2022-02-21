/*                          307. Range Sum Query - Mutable
    Given an integer array nums, handle multiple queries of the following types:

    Update the value of an element in nums.
    Calculate the sum of the elements of nums between indices left and right inclusive where left <= right.
    Implement the NumArray class:

    NumArray(int[] nums) Initializes the object with the integer array nums.
    void update(int index, int val) Updates the value of nums[index] to be val.
    int sumRange(int left, int right) Returns the sum of the elements of nums between indices left and right inclusive (i.e. nums[left] + nums[left + 1] + ... + nums[right]).
    
    Example 1:
        Input
        ["NumArray", "sumRange", "update", "sumRange"]
        [[[1, 3, 5]], [0, 2], [1, 2], [0, 2]]
        Output
        [null, 9, null, 8]
    Explanation
        NumArray numArray = new NumArray([1, 3, 5]);
        numArray.sumRange(0, 2); // return 1 + 3 + 5 = 9
        numArray.update(1, 2);   // nums = [1, 2, 5]
        numArray.sumRange(0, 2); // return 1 + 2 + 5 = 8
    Constraints:
        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        0 <= index < nums.length
        -100 <= val <= 100
        0 <= left <= right < nums.length
        At most 3 * 104 calls will be made to update and sumRange.
*/

using System;

public class RangeSumQueryMutable {
    public RangeSumQueryMutable() {
        string[] functions = {"NumArray","update","sumRange","sumRange","update","sumRange"};
        int[][] input = { new int[]{9,-8},new int[]{0,3},new int[]{1,1},new int[]{0,1},
        new int[]{1,-3},new int[]{0,1} };
    }
}
public class NumArray {
    int[] segmentTree = null, lazyTree = null;
    int numLength = 0;

    public NumArray(int[] nums) {
        CreateSegmentTree();
        void CreateSegmentTree() {
            this.numLength = nums.Length;
            int length = nums.Length;
            if(Math.Floor(Math.Log(length,2)) != Math.Ceiling(Math.Log(length,2))) {
                length = 2;
                while(length < nums.Length)
                    length *= 2;
            }
            length = (length * 2) - 1;
            segmentTree = new int[length];
            lazyTree = new int[length];
            Create(0, nums.Length-1, 0);
            
            void Create(int low, int high, int pos) {
                if(low == high)
                    segmentTree[pos] = nums[low];
                else {
                    int mid = (low+high)/2, left = (2*pos)+1, right = (2*pos)+2;
                    Create(low, mid, left);
                    Create(mid+1, high, right);
                    segmentTree[pos] = segmentTree[left] + segmentTree[right];
                }
            }
        }
    }
  
    public void Update(int index, int val) {
        Update(index, index,0,numLength-1,0);
        void Update(int qMin, int qMax, int sMin, int sMax, int pos) {
            int left = (2*pos)+1, right = (2*pos)+2;
            // lazy tree propagation to its child.
            if(lazyTree[pos] != 0) {
                segmentTree[pos] = lazyTree[pos];
                if(left < lazyTree.Length)
                    lazyTree[left] = lazyTree[pos];
                if(right < lazyTree.Length)
                    lazyTree[right] = lazyTree[pos];
                lazyTree[pos] = 0;
            }
            // No Overlap
            if(sMax < qMin || sMin > qMax)
                return;
            // Total overlap
            if(sMin >= qMin && sMax <= qMax) {
                segmentTree[pos] = val;
                if(left < lazyTree.Length)
                    lazyTree[left] = lazyTree[pos];
                if(right < lazyTree.Length)
                    lazyTree[right] = lazyTree[pos];
                return;
            }
            // Partial overlap
            int mid = (sMin+sMax)/2;
            Update(qMin,qMax,sMin,mid,left);
            Update(qMin,qMax,mid+1,sMax,right);
            segmentTree[pos] = segmentTree[left]+segmentTree[right];
        }
    }
    
    public int SumRange(int left, int right) {
        return SumRange(left,right,0,numLength-1,0);
        int SumRange(int qMin, int qMax, int sMin, int sMax, int pos) {
            int left = (2*pos)+1, right = (2*pos)+2;
            // lazy tree propagation to its child.
            if(lazyTree[pos] != 0) {
                segmentTree[pos] += lazyTree[pos];
                if(left < lazyTree.Length)
                    lazyTree[left] += lazyTree[pos];
                if(right < lazyTree.Length)
                    lazyTree[right] += lazyTree[pos];
                lazyTree[pos] = 0;
            }
            // Total overlap
            if(sMin >= qMin && sMax <= qMax) 
                return segmentTree[pos];
            // No overlaop
            if(sMax < qMin || sMin > qMax)
                return 0;
            // Partially overlaop
            int mid = (sMin+sMax)/2;
            int leftSum = SumRange(qMin,qMax,sMin,mid,left);
            int rightSum = SumRange(qMin,qMax,mid+1,sMax,right);
            return leftSum + rightSum;
        }
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */