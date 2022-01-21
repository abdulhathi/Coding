using System;

public class DeleteBinarySearchTree {
    public DeleteBinarySearchTree() {
        TreeNode root = null; int[] arr = {30,20,10,25,40,35,45,42,43};
        for(int i = 0; i < arr.Length; i++)
            root = InsertInBinarySearchTree.RecursiveInsert(arr[i], root);
        root = DeleteBST(40, root); TreeNode.PrintLevelOrder(root);
        Console.WriteLine();
        root = DeleteBST(200, root); TreeNode.PrintLevelOrder(root);
    }
    public TreeNode DeleteBST(int key, TreeNode root) {
        if(root == null)
            return null;
        if(root.val == key) {
            if(root.left == null && root.right == null)
                return null;
            else {
                TreeNode temp = null;
                if(GetHeight(root.left) > GetHeight(root.right)) {
                    temp = InOrderPredecessor(root);
                    root.val = temp.val;
                    root.left = DeleteBST(temp.val, root.left);
                }
                else {
                    temp = InOrderSuccessor(root);
                    root.val = temp.val;
                    root.right = DeleteBST(temp.val, root.right);
                }
            }
        }
        else if(key < root.val)
            root.left = DeleteBST(key, root.left);
        else
            root.right = DeleteBST(key, root.right);
        return root;
    }
    public int GetHeight(TreeNode root) {
        if(root == null)
            return 0;
        int x = GetHeight(root.left);
        int y = GetHeight(root.right);
        if(root.left == null && root.right == null)
            return x > y ? x : y;
        return (x > y ? x : y) + 1;
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