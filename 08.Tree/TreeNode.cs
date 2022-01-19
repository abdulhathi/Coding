// Definition for a binary tree node.
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
    public static void PrintLevelOrder(TreeNode root) {
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
            // else
            //     Console.Write("null,");
        }
    }
}