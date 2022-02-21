using System;

public class RangeSumQueryImmutable {
    public RangeSumQueryImmutable() {
        // ["NumArray", "sumRange", "sumRange", "sumRange"]
        // [[[-2, 0, 3, -5, 2, -1]], [0, 2], [2, 5], [0, 5]]
    }
}
public class NumArrayImmutable {
    int[] segmentTree = null;
    int numsLength = 0;
    public NumArrayImmutable(int[] nums) {
        CreateSegmentTree();
        void CreateSegmentTree() {
            this.numsLength = nums.Length;
            int length = nums.Length;
            if(Math.Floor(Math.Log(length,2)) != Math.Ceiling(Math.Log(length,2))) {
                length = 2;
                while(length < nums.Length)
                    length *= 2;
            }
            length = (length * 2) - 1;
            segmentTree = new int[length];
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
    
    public int SumRange(int left, int right) {
        return SumRange(left,right,0,numsLength-1,0);
        int SumRange(int qMin, int qMax, int sMin, int sMax, int pos) {
            int left = (2*pos)+1, right = (2*pos)+2;
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
 * int param_1 = obj.SumRange(left,right);
 */