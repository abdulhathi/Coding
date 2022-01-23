using System;

public class RotationOfAVLTree {
    public RotationOfAVLTree() {
        // LL Rotation
        TreeNode root = TreeNode.Create(new int?[] {30,20,40,10,25,null,50,5,15,null,28,null,null,4});
        if(BalanceFactorOfAVLTree.BalanceFactor(root) >= 2 && BalanceFactorOfAVLTree.BalanceFactor(root.left) == 1)
            root = LLRotation(root);
        Console.WriteLine();
        Console.Write("LL Rotation : "); TreeNode.PrintLevelOrder(root);

        // LR Rotation
        root = TreeNode.Create(new int?[] {40,20,50,10,30,null,60,5,null,25,35,null,null,null,null,null,27});
        if(BalanceFactorOfAVLTree.BalanceFactor(root) >= 2 && BalanceFactorOfAVLTree.BalanceFactor(root.right) == -1)
            root = RLRotation(root);
        Console.WriteLine();
        Console.Write("RR Rotation : "); TreeNode.PrintLevelOrder(root);
    }
    public static TreeNode LLRotation(TreeNode root) {
        TreeNode newRoot = root.left;
        root.left = newRoot.right;
        newRoot.right = root;
        return newRoot;
    }
    public static TreeNode RRRotation(TreeNode root) {
        TreeNode newRoot = root.right;
        root.right = newRoot.left;
        newRoot.left = root;
        return newRoot;
    }
    public static TreeNode RLRotation(TreeNode root) {
        TreeNode newRoot = root.left.right;
        root.left.right = newRoot.left;
        newRoot.left = root.left;
        root.left = newRoot.right;
        newRoot.right = root;
        return newRoot;
    }
    public static TreeNode LRRotation(TreeNode root) {
        TreeNode newRoot = root.right.left;
        root.right.left = newRoot.right;
        newRoot.right = root.right;
        root.right = newRoot.left;
        newRoot.left = root;
        return newRoot;
    }
}