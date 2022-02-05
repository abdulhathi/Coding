using System;

public class BuildBinaryTree_Test {
	public class TreeNode {
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
			this.val = val;
			this.left = left;
			this.right = right;
        }
    }
	public BuildBinaryTree_Test() {
		int?[] arr = { 1, 2, 3, null, 4,5, 6,7,8,9 };
		TreeNode tree = BuildBinaryTreeFromArray(arr);
        PrintPreOrder(tree);
    }
    public TreeNode BuildBinaryTreeFromArray(int?[] arr) {
        if(arr == null || arr.Length == 0 || !arr[0].HasValue)
            return null;
        int i = 0;
        TreeNode root = new TreeNode(arr[i++].Value), current = null;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count > 0) {
            current = queue.Dequeue();
            if(current != null) {
                if(arr.Length > i) {
                    current.left = arr[i] != null ? new TreeNode(arr[i].Value):null;
                    queue.Enqueue(current.left);
                    i++;
                }
                if(arr.Length > i) {
                    current.right = arr[i] != null ? new TreeNode(arr[i].Value):null;
                    queue.Enqueue(current.right);
                    i++;
                }
            }
        }
        return root;
    }
    public void PrintPreOrder(TreeNode root) {
        if(root != null) {
            PrintPreOrder(root.left);
            Console.Write(root.val+",");
            PrintPreOrder(root.right);
        }
    }
}
