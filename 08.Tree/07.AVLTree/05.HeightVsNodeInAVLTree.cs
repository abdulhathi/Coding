using System;

public class HeightVsNodeInAVLTree {
    public HeightVsNodeInAVLTree() {
        Console.WriteLine();
        Console.WriteLine("Min Node : {0}", FindMinNodes(4));
        Console.WriteLine("Max Node : {0}", FindMaxNodes(4));

        Console.WriteLine("Min Height : {0}", FindMinHeight(15));
        Console.WriteLine("Max Height : {0}", FindMaxHeight(7));
    }
    public int FindMinNodes(int height) {
        // Forumal : n = Min(h-2) + Min(h-1) + 1
        if(height == 0)
            return 0;
        if(height == 1)
            return 1;
        return FindMinNodes(height - 2) + FindMinNodes(height - 1) + 1;
    }
    public int FindMaxNodes(int height) {
        //Formula : 2^(h+1) - 1
        return Convert.ToInt32(Math.Pow(2, height)) - 1;
    }
    public int FindMinHeight(int node) {
        //Forumula: Log base2 (n+1)
        return Convert.ToInt32(Math.Log2(node+1));
    }
    public int FindMaxHeight(int node) {
        return Convert.ToInt32(1.44*Math.Log2(node+1));
    }
}