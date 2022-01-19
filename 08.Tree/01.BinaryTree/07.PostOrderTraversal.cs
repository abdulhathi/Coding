using System;

public class PostOrderTraversal {
    public PostOrderTraversal() {
        TreeNode binaryTree = CreateBinaryTree.CreateByIterativeQueue(new int?[] {1,2,3,null,4,5,6});
        RecursivePostOrder(binaryTree);
        Console.WriteLine();
        IterativePostOrder(binaryTree);
    }
    public void RecursivePostOrder(TreeNode root) {
        if(root != null) {
            RecursivePostOrder(root.left);
            RecursivePostOrder(root.right);
            Console.Write(root.val+",");
        }
    }
    public void IterativePostOrder(TreeNode root) {
        var stack = new Stack<(TreeNode node, bool flag)>();
        while(root != null || stack.Count > 0) {
            if(root != null) {
                stack.Push((root, true));
                root = root.left;
            }
            else {
                if(stack.Peek().flag) {
                    root = stack.Pop().node;
                    stack.Push((root, false));
                    root = root.right;
                }
                else {
                    Console.Write(stack.Pop().node.val+",");
                }
            }
        }
    }
}