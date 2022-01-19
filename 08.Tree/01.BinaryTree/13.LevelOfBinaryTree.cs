using System;

public class LevelOfBinaryTree {
    public LevelOfBinaryTree() {
        TreeNode binaryTree = CreateBinaryTree.CreateByIterativeQueue(new int?[] {8,3,5,12,null,10,6,null,4,null,null,2,null,9,7});
        int level = GetLevel(binaryTree);
        Console.WriteLine($"Level of this tree : {level}");
    }
    public int GetLevel(TreeNode root) {
        if(root == null)
            return 0;
        int x = GetLevel(root.left);
        int y = GetLevel(root.right);
        return (x < y ? x : y) + 1;
    }
}