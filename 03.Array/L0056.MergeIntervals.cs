using System;

public class MergeIntervals {
    public MergeIntervals() {

    }
    public int[][] Merge(int[][] intervals) {
        List<int[]> merged = new List<int[]>();
        merged.Add(new int[] {intervals[0][0], intervals[0][1]});
        int m = 0;
        for(int i = 1; i < intervals.Length; i++) {
            if((intervals[i][0] >= merged[m][0] && intervals[i][0] <= merged[m][1]) || 
            (merged[m][0] >= intervals[i][0] && merged[m][0] <= intervals[i][1])) {
                merged[m][0] = Math.Min(merged[m][0], intervals[i][0]);
                merged[m][1] = Math.Max(merged[m][1], intervals[i][1]);
            }
            else {
                merged.Add(new int[] {intervals[i][0],intervals[i][1]});
                m++;
            }    
        }
        return merged.ToArray();
    }
}