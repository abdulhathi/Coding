using System;

public class InsertInBinarySearchTree {
    public InsertInBinarySearchTree() {
        int[] keys = {40,20,10,30,70,60,50,80};
        TreeNode tree = null;
        for(int i = 0; i < keys.Length; i++) 
            tree = RecursiveInsert(keys[i], tree);
        PrintInOrder(tree);
    }
    public void PrintInOrder(TreeNode root) {
        if(root != null) {
            PrintInOrder(root.left);
            Console.Write(root.val+",");
            PrintInOrder(root.right);
        }
    }
    public TreeNode IterativeInsert(int key, TreeNode tree) {
        TreeNode root = tree;
        TreeNode temp = null;
        while(root != null) {
            temp = root;
            if(root.val == key)
                return null;
            else if(key < root.val)
                root = root.left;
            else
                root = root.right;
        }
        if(temp == null)
            return new TreeNode(key);
        if(key < temp.val)
            temp.left = new TreeNode(key);
        else if(key > temp.val)
            temp.right = new TreeNode(key);
        return tree;
    }
    public static TreeNode RecursiveInsert(int key, TreeNode root) {
        if(root == null)
            return new TreeNode(key);
        if(key == root.val)
            return null;
        else if(key < root.val)
            root.left = RecursiveInsert(key, root.left);
        else
            root.right = RecursiveInsert(key, root.right);
        return root;
    }
}