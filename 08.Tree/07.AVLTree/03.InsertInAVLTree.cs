using System;

public class InsertInAVLTree {
    public InsertInAVLTree() {
        int[] keys = {10,20,30,25,28,27,5};
        TreeNode root = null;
        for(int i = 0; i < keys.Length; i++)
            root = Insert(keys[i], root);
        TreeNode.PrintLevelOrder(root);
    }
    public TreeNode Insert(int key, TreeNode root) {
        if(root == null)
            return new TreeNode(key);
        else if(key < root.val) 
            root.left = Insert(key, root.left);
        else
            root.right = Insert(key, root.right);
        
        int rootBF = BalanceFactorOfAVLTree.BalanceFactor(root);
        int rootLeftBF = BalanceFactorOfAVLTree.BalanceFactor(root.left);
        int rootRightBF = BalanceFactorOfAVLTree.BalanceFactor(root.right);
        if(rootBF >= 2) {
            if(rootLeftBF == 1 || rootLeftBF == 0)
                root = RotationOfAVLTree.LLRotation(root);
            else if(rootLeftBF == -1 || rootLeftBF == 0)
                root = RotationOfAVLTree.RLRotation(root);
        }
        else if(rootBF <= -2) {
            if(rootRightBF == -1 || rootRightBF == 0)
                root = RotationOfAVLTree.RRRotation(root);
            else if(rootRightBF == 1 || rootRightBF == 0)
                root = RotationOfAVLTree.LRRotation(root);
        }
        return root;
    }
}