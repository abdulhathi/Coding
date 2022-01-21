using System;

public class MaximumDepthOfBinaryTree {
    public MaximumDepthOfBinaryTree() {
        Console.WriteLine(MaxDepth(CreateBinaryTree.CreateByIterativeQueue(new int?[] {3,9,20,null,null,15,7})));
    }
    public int MaxDepth(TreeNode root) {
        if(root == null)
            return 0;
        int x = MaxDepth(root.left);
        int y = MaxDepth(root.right);
        return (x > y ? x : y) + 1;
    }
}