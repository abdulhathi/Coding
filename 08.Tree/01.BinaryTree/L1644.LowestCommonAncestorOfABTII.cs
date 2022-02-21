/*      236. Lowest Common Ancestor of a Binary Tree

*/
using System;

public class LowestCommonAncestorOfABTII {
    public class LCAExist {
        public bool PExist;
        public bool QExist;
        public TreeNode Node;
        public LCAExist(bool p = false, bool q = false, TreeNode node = null) {
            this.PExist = p;
            this.QExist = q;
            this.Node = node;
        }
    }
    public LowestCommonAncestorOfABTII() {
        TreeNode root = TreeNode.Create(new int?[] {3,5,1,6,2,0,8,null,null,7,4});
        var node = LowestCommonAncestor(root, root.left.right.left, root.left.right.right);
        Console.WriteLine(node.val);
    }
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var lca = DFS(root);
        return lca.PExist && lca.QExist ? lca.Node : null;
        LCAExist DFS(TreeNode root) {
            if(root == null)
                return new LCAExist();
            var left = DFS(root.left);
            var right = DFS(root.right);
            var current = new LCAExist(left.PExist || right.PExist, left.QExist || right.QExist,
                                      left.Node != null ? left.Node : right.Node);
            if(!current.PExist)
                current.PExist = (root == p);
            if(!current.QExist)
                current.QExist = (root == q);
            if(current.PExist && current.QExist && current.Node == null)
                current.Node = root;
            return current;
        }
    }
}