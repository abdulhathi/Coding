using System;

public class LevelByLevelReverseBTDisplay {
    public LevelByLevelReverseBTDisplay() {
        var result = LevelByLevelReverse(TreeNode.Create(new int?[] {10,20,30,40,50,null,60,null,null,70,80,90}));
        Console.WriteLine(string.Join(",", result));
    }
    public IList<int> LevelByLevelReverse(TreeNode root) {
        // Level order from bottom to top
        Stack<int> stack = new Stack<int>();
        List<int> result = new List<int>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        TreeNode current = null;
        while(queue.Count > 0) {
            current = queue.Dequeue();
            stack.Push(current.val);
            if(current.right != null) queue.Enqueue(current.right);
            if(current.left != null) queue.Enqueue(current.left);
        }
        while(stack.Count > 0)
            result.Add(stack.Pop());
        return result;
    }
}