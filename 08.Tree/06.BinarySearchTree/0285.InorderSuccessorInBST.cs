using System;

public class InorderSuccessorInBST {
    public InorderSuccessorInBST() {
        TreeNode root = TreeNode.Create(new int?[] {5,3,6,2,4,null,null,1});
        TreeNode successor = InorderSuccessor(root, root.left.right);
        Console.WriteLine(successor != null ? successor.val.ToString() : "null");
    }
    public TreeNode InorderSuccessor_Method1(TreeNode root, TreeNode p) {
        List<TreeNode> inorder = new List<TreeNode>();
        InOrderTraversal(root, inorder);
        for(int i = 0; i < inorder.Count; i++)
            if(inorder[i].val == p.val)
                return i+1 < inorder.Count ? inorder[i+1] : null;
        return null;
    }
    public void InOrderTraversal(TreeNode root, List<TreeNode> inorder) {
        if(root != null) {
            InOrderTraversal(root.left, inorder);
            inorder.Add(root);
            InOrderTraversal(root.right, inorder);
        }
    }

    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        TreeNode lastLeftTaken = null;
        TreeNode parent = null;
        while(root != null) {
            if(root == p) {
                if(root.right != null)
                    return FindInorderSuccessor(root);
                else {
                    if(parent != null && parent.left == root)
                        return parent;
                    else
                        return lastLeftTaken;
                }
            }
            else if(p.val < root.val) {
                parent = root;
                lastLeftTaken = root;
                root = root.left;
            }
            else {
                parent = root;
                root = root.right;
            }
        }
        return null;
    }
    public TreeNode FindInorderSuccessor(TreeNode root) {
        TreeNode temp = root.right;
        while(temp != null && temp.left != null) 
            temp = temp.left;
        return temp;
    }
}