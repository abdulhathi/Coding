using System;

public class LowestCommonAncestorInBT {
    public LowestCommonAncestorInBT() {
        TreeNode root = TreeNode.Create(new int?[] {3,6,8,2,11,null,13,null,null,9,5,7,null});
        TreeNode node1 = root.left.left, node2 = root;
        TreeNode lca = LCAOfBinaryTree(root, node1, node2);
        Console.WriteLine("{0}", lca != null ? lca.val.ToString() : "null");
    }
    public TreeNode LCAOfBinaryTree(TreeNode root, TreeNode node1, TreeNode node2) {
        if(root == null)
            return null;
        if(root == node1 || root == node2)
            return root;
        TreeNode left = LCAOfBinaryTree(root.left, node1, node2);
        TreeNode right = LCAOfBinaryTree(root.right, node1, node2);
        if(left != null && right != null)
            return root;
        return left != null ? left : right;
    }
}