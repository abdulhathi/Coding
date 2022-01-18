using System;

public class HeightVsNodeInBinaryTree {
    public HeightVsNodeInBinaryTree() {
        Console.WriteLine($"Min nodes by height : {FindMinNode(3)}");
        Console.WriteLine($"Max nodes by height : {FindMaxNode(3)}");
        Console.WriteLine($"Min height by node : {FindMinHeight(5)}");
        Console.WriteLine($"Max height by node : {FindMaxHeight(5)}");
    }
    public int FindMinNode(int height) {
        // Formula : n = h+1;
        return height + 1;
    }
    public int FindMaxNode(int height) {
        // Formula : n = 2^(h+1) - 1
        return Convert.ToInt32(Math.Pow(2, height+1)) - 1;
    }
    public int FindMinHeight(int node) {
        // Formula : h = log2(n+1) - 1;
        return Convert.ToInt32(Math.Log2(node+1)) - 1;
    }
    public int FindMaxHeight(int node) {
        // Formula : h = n - 1;
        return node - 1;
    }
}