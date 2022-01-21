using System;

public class BreadthFirstSearchOfBinaryTree {
    public BreadthFirstSearchOfBinaryTree() {
        var root = CreateBinaryTree.CreateByIterativeQueue(new int?[] {8,3,5,12,null,10,6,null,4,null,null,2,null,9,7});
        BFS(root);
    }
    public void BFS(TreeNode root) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count > 0) {
            root = queue.Dequeue();
            if(root != null) {
                Console.Write(root.val+",");
                queue.Enqueue(root.left);
                queue.Enqueue(root.right);
            }
        }
    }
}