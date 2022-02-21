using System;

public class LowestCommonAncestorOfABST {
    public LowestCommonAncestorOfABST() {
        var root = TreeNode.Create(new int?[] {6,2,8,0,4,7,9,null,null,3,5});
        var lcaNode = LowestCommonAncestor(root, root.left,root.left.right);
        Console.WriteLine(lcaNode.val);
    }
     public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if(root == null)
            return null;
        if(Math.Min(p.val,q.val) <= root.val && Math.Max(p.val,q.val) >= root.val)
            return root;
        else if(root.val > Math.Max(p.val,q.val))
            return LowestCommonAncestor(root.left,p,q);
        else
            return LowestCommonAncestor(root.right,p,q);
    }
}