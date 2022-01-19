using System;

public class CreateBinaryTree {
    public CreateBinaryTree()
    {
        TreeNode binaryTree = CreateByIterativeQueue(new int?[] {1,2,3,null,4,5,6});
        TreeNode.PrintLevelOrder(binaryTree);
    }
    public static TreeNode CreateByIterativeQueue(int?[] input) {
        if(input == null || input[0] == null)
            return null;
        int i = 0;
        TreeNode root = new TreeNode(input[i++].Value);
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        TreeNode current = null;
        while(queue.Count > 0) {
            current = queue.Dequeue();
            if(current != null) {
                if(input.Length > i) {
                    current.left = input[i].HasValue ? new TreeNode(input[i].Value) : null;
                    queue.Enqueue(current.left);
                    i++;
                }
                if(input.Length > i) {
                    current.right = input[i].HasValue ? new TreeNode(input[i].Value) : null;
                    queue.Enqueue(current.right);
                    i++;
                }
            }
        }
        return root;
    }
}