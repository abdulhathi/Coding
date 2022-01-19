using System;

public class HeightOfBinaryTree {
    public HeightOfBinaryTree() {
        TreeNode binaryTree = CreateBinaryTree.CreateByIterativeQueue(new int?[] {8,3,5,12,null,10,6,null,4,null,null,2,null,9,7});
        int height = GetHeight(binaryTree);
        Console.WriteLine($"Height of this tree : {height}");
    }
    public int GetHeight(TreeNode root) {
        if(root == null)
            return 0;
        int x = GetHeight(root.left);
        int y = GetHeight(root.right);
        if(root.left == null && root.right == null)
            return x > y ? x : y;
        return (x > y ? x : y) + 1;
    }
}