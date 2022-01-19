using System;

public class SumOfAllNodesInBinaryTree {
    public SumOfAllNodesInBinaryTree() {
        TreeNode binaryTree = CreateBinaryTree.CreateByIterativeQueue(new int?[] {8,3,5,12,null,10,6,null,4,null,null,2,null,9,7});
        int sum = GetSum(binaryTree);
        Console.WriteLine($"Sum all the nodes of this tree : {sum}");
    }
    public int GetSum(TreeNode root) {
        return root == null ? 0 : GetSum(root.left) + GetSum(root.right) + root.val;
    }
}