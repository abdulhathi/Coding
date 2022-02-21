using System;

public class QueryMinSegmentTree {
    /*
            0   1   2   3   4   5
            -1  3   4   0   2   1
    */
    public QueryMinSegmentTree() {
        int[] arr = new int[] {-1,3,4,0,2,1};
        int[] segmentTree = CreateMinSegmentTree.Create(arr);
        int min = QueryRangeToFindMin(segmentTree, 1, 2, 0, arr.Length - 1, 0);
        Console.WriteLine(min);
    }
    public int QueryRangeToFindMin(int[] segmentTree, int qMin, int qMax, int sMin, int sMax, int pos) {
        // Total overlap
        if(sMin >= qMin && sMax <= qMax) 
            return segmentTree[pos];
        // No overlap
        else if(sMax < qMin || sMin > qMax)
            return int.MaxValue;
        // Partial Overlap
        else {
            int mid = (sMin+sMax)/2, left = (2*pos)+1, right = (2*pos)+2;
            int leftMin = QueryRangeToFindMin(segmentTree, qMin, qMax, sMin, mid, left);
            int rightMin = QueryRangeToFindMin(segmentTree, qMin, qMax, mid+1, sMax, right);
            return Math.Min(leftMin, rightMin);
        }
    }
}