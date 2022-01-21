using System;

public class SameTree {
    public SameTree() {
        TreeNode p = new TreeNode(1, new TreeNode(2), new TreeNode(3));
        TreeNode q = new TreeNode(1, new TreeNode(2), new TreeNode(4));
        Console.WriteLine(IsSameTree(p,q));
    }
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if(p == null && q == null)
            return true;
        if((p == null && q != null) || (p != null && q == null))
            return false;
        bool left = IsSameTree(p.left, q.left);
        bool right = IsSameTree(p.right, q.right);
        return left && right && p.val == q.val;
    }
}