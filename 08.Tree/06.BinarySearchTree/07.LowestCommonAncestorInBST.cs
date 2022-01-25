using System;

public class LowestCommonAncestorInBST {
    public LowestCommonAncestorInBST() {
        TreeNode root = TreeNode.Create(new int?[] {10,-10,30,null,8,25,60,6,9,null,28,null,78});
        TreeNode lca = LCAOfBinarySearchTree(root, 30, 78);
        Console.WriteLine("{0}", lca != null ? lca.val.ToString() : "null");
    }
    public TreeNode LCAOfBinarySearchTree(TreeNode root, int val1, int val2) {
        if(root.val > Math.Max(val1,val2))
            return LCAOfBinarySearchTree(root.left, val1, val2);
        else if(root.val < Math.Min(val1,val2))
            return LCAOfBinarySearchTree(root.right, val1, val2);
        else
            return root;
    }
}