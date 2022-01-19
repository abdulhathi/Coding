using System;

public class CountNodesInBinaryTree {
    public CountNodesInBinaryTree() {
        TreeNode binaryTree = CreateBinaryTree.CreateByIterativeQueue(new int?[] {8,3,5,12,null,10,6,null,4,null,null,2,null,9,7});
        int count = GetCount(binaryTree);
        Console.WriteLine($"Node count of this tree : {count}");
    }
    public int GetCount(TreeNode root) {
        return root == null ? 0 : GetCount(root.left) + GetCount(root.right) + 1;
    }
}