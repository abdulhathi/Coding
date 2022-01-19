using System;

public class PreOrderTraversal {
    public PreOrderTraversal() {
        TreeNode binaryTree = CreateBinaryTree.CreateByIterativeQueue(new int?[] {1,2,3,null,4,5,6});
        Console.WriteLine("Recursive Pre order of Binary Tree : ");
        RecursivePreOrder(binaryTree);
        Console.WriteLine("\n Iterative Pre order of Binary Tree : ");
        IterativePreOrder(binaryTree);
    }
    public void RecursivePreOrder(TreeNode root) {
        if(root != null) {
            Console.Write(root.val+",");
            RecursivePreOrder(root.left);
            RecursivePreOrder(root.right);
        }
    }
    public void IterativePreOrder(TreeNode root) {
        TreeNode current = root;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        while(current != null || stack.Count > 0) {
            if(current != null) {
                Console.Write(current.val+",");
                stack.Push(current);
                current = current.left;
            }
            else {
                current = stack.Pop().right;
            }   
        }
    }
}