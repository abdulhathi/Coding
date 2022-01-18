using System;

public class HeightVsNodeInStrictBinaryTree {
    public HeightVsNodeInStrictBinaryTree() {
        Console.WriteLine();
        FindMinNodes(3);
        FindMaxNodes(3);
        FindMinHeight(15);
        FindMaxHeight(15);
    }
    public void FindMinNodes(int height) {
        // formula Node = 2*h + 1
        Console.WriteLine($"Min number of nodes : {(2*height) + 1}");
    }
    public void FindMaxNodes(int height) {
        // formula Node = 2^(h+1) - 1
        Console.WriteLine($"Max number of nodes : {Convert.ToInt32(Math.Pow(2, height+1))-1}");
    }
    public void FindMinHeight(int node) {
        // height = log2(n+1) - 1
        Console.WriteLine($"Min Height for the given nodes : {Convert.ToInt32(Math.Log2(node+1)) - 1}");

    }
    public void FindMaxHeight(int node) {
        // height = (n-1)/2
        Console.WriteLine($"Max height for the given nodes : {(node-1)/2}");
    }
}