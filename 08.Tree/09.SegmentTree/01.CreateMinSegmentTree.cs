using System;

public class CreateMinSegmentTree {
    public CreateMinSegmentTree() {
        var segmentTree = Create(new int[] {-1,3,4,0,2,1});
        Console.WriteLine(string.Join(",",segmentTree));
    }
    public static int[] Create(int[] arr) {
        int len = arr.Length;
        if(Math.Floor(Math.Log(arr.Length,2)) != Math.Ceiling(Math.Log(arr.Length,2))) {
            len = 2;
            while(len < arr.Length)
                len *= 2; 
        }
        len = (len * 2) - 1;
        int[] segmentTree = new int[len];

        CreateTree(0, 0, arr.Length-1);

        void CreateTree(int pos, int low, int high) {
            if(low == high) 
                segmentTree[pos] = arr[low];
            else {
                int mid = (low+high)/2, left = (2*pos)+1, right = (2*pos)+2;
                // left sub tree
                CreateTree(left, low, mid);
                // right sub tree
                CreateTree(right, mid+1, high);
                segmentTree[pos] = Math.Min(segmentTree[left], segmentTree[right]);
            }
        }

        return segmentTree;
    }
}