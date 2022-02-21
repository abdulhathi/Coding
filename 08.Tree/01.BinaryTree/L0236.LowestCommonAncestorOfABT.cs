/*      236. Lowest Common Ancestor of a Binary Tree

*/
using System;

public class LowestCommonAncestorOfABT {
    public LowestCommonAncestorOfABT() {
        TreeNode root = TreeNode.Create(new int?[] {3,5,1,6,2,0,8,null,null,7,4});
        var node = LowestCommonAncestor(root, root.left, root.right);
        Console.WriteLine(node.val);
    }
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if(root == null)
            return null;
        if(root == p || root == q)
            return root;
        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);
        return left != null && right != null ? root : (right == null ? left : right);
    }
}