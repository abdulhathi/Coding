using System;

public class LazyPropagationInSegmentTree {
    int[] segmentTree = null, lazyTree = null;
    public LazyPropagationInSegmentTree() {
        var arr = new int[] {-1,2,4,1,7,1,3,2};
        segmentTree = CreateMinSegmentTree.Create(arr);
        lazyTree = new int[segmentTree.Length];
        Console.WriteLine();
        Console.WriteLine(string.Join(",", segmentTree));
        TestCase(0,3,3,arr);
        TestCase(0,3,1,arr);
        TestCase(0,0,2,arr);
        
        // while(Console.In.ReadLine() == "new") {
        //     string[] input = Console.ReadLine().Split(" ");
        //     int min = Convert.ToInt32(input[0]), max = Convert.ToInt32(input[1]), 
        //     value = Convert.ToInt32(input[2]);;
        //     UpdateRangeValue(min,max,0,arr.Length-1,0,value);
        //     Console.WriteLine(string.Join(",", segmentTree));
        //     Console.WriteLine(string.Join(",", lazyTree));
        // }
    }
    public void TestCase(int min, int max, int val, int[] arr)
    {
        UpdateRangeValue(min,max,0,arr.Length-1,0,val);
        Console.WriteLine(string.Join(",", segmentTree));
        Console.WriteLine(string.Join(",", lazyTree));
    }
    public void UpdateRangeValue(int qMin, int qMax, int sMin, int sMax, int pos, int value) {
        int left = (2*pos)+1, right = (2*pos)+2;
        if(lazyTree[pos] != 0) {
            segmentTree[pos] += lazyTree[pos];
            if(left < lazyTree.Length)
                lazyTree[left] += lazyTree[pos];
            if(right < lazyTree.Length)
                lazyTree[right] += lazyTree[pos];
            lazyTree[pos] = 0;
        }
        // No overlap
        if(sMax < qMin || sMin > qMax)
            return;
        // Total overlap
        if(sMin >= qMin && sMax <= qMax) {
            segmentTree[pos] += value;
            if(left < lazyTree.Length)
                lazyTree[left] += value;
            if(right < lazyTree.Length)
                lazyTree[right] += value;
            return;
        }
        // Partial overlap
        int mid = (sMin+sMax) / 2;
        UpdateRangeValue(qMin, qMax, sMin, mid, left, value);
        UpdateRangeValue(qMin, qMax, mid+1, sMax, right, value);
        segmentTree[pos] = Math.Min(segmentTree[left],segmentTree[right]);
    }
}