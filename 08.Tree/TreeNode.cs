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
    public TreeNode(int? val = null, int? left = null, int? right = null) {
        this.val = val.Value;
        this.left = left.HasValue ? new TreeNode(left.Value) : null;
        this.right = right.HasValue ? new TreeNode(right.Value) : null;
    }
    public static TreeNode Create(int?[] arr) {
        int i = 0;
        if(arr == null || arr.Length == 0 || arr[i] == null)
            return null;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        TreeNode root = new TreeNode(arr[i++].Value);
        queue.Enqueue(root);
        TreeNode current = null;
        while(queue.Count > 0) {
            current = queue.Dequeue();
            if(current != null) {
                if(arr.Length > i) {
                    current.left = arr[i].HasValue ? new TreeNode(arr[i].Value) : null;
                    queue.Enqueue(current.left);
                    i++;
                }
                if(arr.Length > i) {
                    current.right = arr[i].HasValue ? new TreeNode(arr[i].Value) : null;
                    queue.Enqueue(current.right);
                    i++;
                }
            }
        }
        return root;
    }
    public static void PrintLevelOrder(TreeNode root) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        TreeNode current = null;
        while(queue.Count > 0) {
            current = queue.Dequeue();
            if(current != null) {
                Console.Write(current.val+",");
                if(current.left != null || current.right != null) {
                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                }
            }
            else
                Console.Write("null,");
        }
    }
    public static void PrintPostOrder(TreeNode root) {
        if(root != null) {
            PrintPostOrder(root.left);
            PrintPostOrder(root.right);
            Console.Write(root.val+",");
        }
    }
}