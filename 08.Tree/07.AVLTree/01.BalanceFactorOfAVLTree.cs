using System;

public class BalanceFactorOfAVLTree {
    public BalanceFactorOfAVLTree() {
        
    }
    public static int GetHeight(TreeNode root) {
        if(root == null)
            return 0;
        int x = GetHeight(root.left) , y = GetHeight(root.right);
        return (x > y ? x : y) + 1;
    }
    public static int BalanceFactor(TreeNode root) {
        if(root == null)
            return 0;
        return GetHeight(root.left) - GetHeight(root.right);
    }
}