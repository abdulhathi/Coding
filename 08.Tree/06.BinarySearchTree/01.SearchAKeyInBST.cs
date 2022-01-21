using System;

public class SearchAKeyInBST {
    public SearchAKeyInBST() {
        TreeNode bst = new TreeNode(30, new TreeNode(20, 10, 25), new TreeNode(40, 35, 50));
        Console.WriteLine("Recursive search : Key {0}found in the BST.", RecursiveSearch(41, bst) == null ? "not " : "");
        Console.WriteLine("Iterative search : Key {0}found in the BST.", IterativeSearch(40, bst) == null ? "not " : "");
    }
    public TreeNode RecursiveSearch(int key, TreeNode root) {
        if(root == null)
            return null;
        if(root.val == key)
            return root;
        else if(key < root.val)
            return RecursiveSearch(key, root.left);
        else
            return RecursiveSearch(key, root.right);
    }
    public TreeNode IterativeSearch(int key, TreeNode root) {
        TreeNode temp = root;
        while(temp != null) {
            if(temp.val == key)
                return temp;
            else if(key < temp.val)
                temp = temp.left;
            else
                temp = temp.right;
        }
        return null;
    }
}