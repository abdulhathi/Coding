using System;

public class NodeCountByDegree {
    public NodeCountByDegree() {
        TreeNode binaryTree = CreateBinaryTree.CreateByIterativeQueue(new int?[] {8,3,5,12,null,10,6,null,4,null,null,2,null,9,7});
        Console.WriteLine();
        Console.WriteLine($"Count of all leaf nodes in this tree    : {LeafNodesCount(binaryTree)}");
        Console.WriteLine($"Degree two node count in this tree      : {Degree2NodeCount(binaryTree)}");
        Console.WriteLine($"Degree one node count in this tree      : {Degree1NodeCount(binaryTree)}");
    }
    public int LeafNodesCount(TreeNode root) {
        if(root == null)
            return 0;
        int x = LeafNodesCount(root.left);
        int y = LeafNodesCount(root.right);
        if(root.left == null && root.right == null)
            return x + y + 1;
        return x + y;
    }
    public int Degree2NodeCount(TreeNode root) {
        if(root == null) 
            return 0;
        int x = Degree2NodeCount(root.left);
        int y = Degree2NodeCount(root.right);
        if(root.left != null && root.right != null)
            return x + y + 1;
        return x + y;
    }
    public int Degree1NodeCount(TreeNode root) {
        if(root == null) 
            return 0;
        int x = Degree1NodeCount(root.left);
        int y = Degree1NodeCount(root.right);
        //if((root.left == null && root.right != null) || (root.left != null && root.right == null))
        if(root.left != null ^ root.right != null)
            return x + y + 1;
        return x + y;
    }
}