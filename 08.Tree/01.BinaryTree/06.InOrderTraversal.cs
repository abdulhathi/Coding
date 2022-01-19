using System;

public class InOrderTraversal {
    public InOrderTraversal() {
        TreeNode binaryTree = CreateBinaryTree.CreateByIterativeQueue(new int?[] {1,2,3,null,4,5,6});
        RecursiveInOrder(binaryTree);
        Console.WriteLine();
        IterativeInOrder(binaryTree);
    }
    public void RecursiveInOrder(TreeNode root) {
        if(root != null) {
            RecursiveInOrder(root.left);
            Console.Write(root.val+" ");
            RecursiveInOrder(root.right);
        }
    }
    public void IterativeInOrder(TreeNode root) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        while(root != null || stack.Count > 0) {
            if(root != null) {
                stack.Push(root);
                root = root.left;
            }
            else {
                root = stack.Pop();
                Console.Write(root.val+",");
                root = root.right;
            }
        }
    }
}