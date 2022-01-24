using System;

public class CountNodesEqualToSumOfDescendants {
    public CountNodesEqualToSumOfDescendants() {
        TreeNode root = TreeNode.Create(new int?[] {10,3,4,2,1});
        int count = EqualToDescendants(root);
        Console.WriteLine(count);
    }
    public int EqualToDescendants(TreeNode root) {
        var totalSumAndCount = CountAndSum(root);
        return totalSumAndCount.count;
    }
    public (int sum, int count) CountAndSum(TreeNode root) {
        if(root == null)
            return (0, 0);
        var x = CountAndSum(root.left);
        var y = CountAndSum(root.right);
        if(x.sum + y.sum == root.val)
            return (x.sum + y.sum+root.val, x.count + y.count + 1);
        return (x.sum + y.sum + root.val, x.count + y.count);
    } 
}