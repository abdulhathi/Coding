using System;

public class LevelOrderTraversal {
    public LevelOrderTraversal() {
         TreeNode binaryTree = CreateBinaryTree.CreateByIterativeQueue(new int?[] {1,2,3,null,4,5,6});
        IterativeLevelOrder(binaryTree);
    }
    public void IterativeLevelOrder(TreeNode root) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        TreeNode current = null;
        while(queue.Count > 0) {
            current = queue.Dequeue();
            if(current != null) {
                Console.Write(current.val+",");
                queue.Enqueue(current.left);
                queue.Enqueue(current.right);
            }
        }
    }
}