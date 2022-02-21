/*      236. Lowest Common Ancestor of a Binary Tree

*/
using System;

public class LowestCommonAncestorOfABTIV {
    public LowestCommonAncestorOfABTIV() {
        var root = TreeNode.Create(new int?[] {3,5,1,6,2,0,8,null,null,7,4});
        var node = LowestCommonAncestor(root, new TreeNode[] { root.left.right.left, root.left.right.right });
        Console.WriteLine(node.val);
    }
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode[] nodes) {
        var nodeSet = new HashSet<TreeNode>();
        foreach(var node in nodes)
            nodeSet.Add(node);
        return DFS(root);
        
        TreeNode DFS(TreeNode root) {
            if(root == null) 
                return null;
            var left = DFS(root.left);
            var right =DFS(root.right);
            if(nodeSet.Contains(root)) {
                nodeSet.Remove(root);
                return root;
            }
            return left != null && right != null ? root : (left != null ? left : right);
        }
    }
}