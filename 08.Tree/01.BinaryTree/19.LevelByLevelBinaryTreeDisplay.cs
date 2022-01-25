using System;

public class LevelByLevelBinaryTreeDisplay {
    public LevelByLevelBinaryTreeDisplay() {
        var result = LevelByLevel(TreeNode.Create(new int?[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20})); 
        Console.WriteLine();
        foreach(var level in result)
            Console.WriteLine(string.Join(",", level));
    }
    public IList<IList<int>> LevelByLevel(TreeNode root) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        List<IList<int>> result = new List<IList<int>>();
        queue.Enqueue(root);
        queue.Enqueue(null);
        TreeNode current = null;
        List<int> nodeByLevel = new List<int>();
        while(queue.Count > 0) {
            current = queue.Dequeue();
            if(current != null) {
                nodeByLevel.Add(current.val);
                if(current.left != null) queue.Enqueue(current.left);
                if(current.right != null) queue.Enqueue(current.right);
            }
            else {
                result.Add(nodeByLevel);
                nodeByLevel = new List<int>();
                if(queue.Count > 0) queue.Enqueue(null);
            }
        }
        return result;
    }
}