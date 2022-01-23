using System;

public class DeleteNodeInAVLTree {
    public DeleteNodeInAVLTree() {
        TreeNode root = TreeNode.Create(new int?[] {30,10,40,5,20});
        root = Delete(40, root);
        TreeNode.PrintLevelOrder(root);
    }
    public TreeNode Delete(int key, TreeNode root) {
        if(root == null) return null;
        if(key == root.val) {
            if(root.left == null && root.right == null)
                return null;
            else {
                if(BalanceFactorOfAVLTree.GetHeight(root.left) > BalanceFactorOfAVLTree.GetHeight(root.right))
                {
                    TreeNode temp = InOrderPredecessor(root);
                    root.val = temp.val;
                    root.left = Delete(temp.val, root.left);
                }
                else {
                    TreeNode temp = InOrderSuccessor(root);
                    root.val = temp.val;
                    root.right = Delete(temp.val, root.right);
                }
            }
        }
        else if(key < root.val)
            root.left = Delete(key, root.left);
        else
            root.right = Delete(key, root.right);
        
        int rootBF = BalanceFactorOfAVLTree.BalanceFactor(root);
        if(rootBF >= 2)
            root = BalanceFactorOfAVLTree.BalanceFactor(root.left) == -1 ? RotationOfAVLTree.RLRotation(root) : RotationOfAVLTree.LLRotation(root);
        else if(rootBF <= -2)
            root = BalanceFactorOfAVLTree.BalanceFactor(root.right) == 1 ? RotationOfAVLTree.LRRotation(root) : RotationOfAVLTree.RRRotation(root);
        return root;
    }
    public TreeNode InOrderPredecessor(TreeNode root) {
        TreeNode temp = root.left;
        while(temp != null && temp.right != null)
            temp = temp.right;
        return temp;
    }
    public TreeNode InOrderSuccessor(TreeNode root) {
        TreeNode temp = root.right;
        while(temp != null && temp.left != null)
            temp = temp.left;
        return temp;
    }
}