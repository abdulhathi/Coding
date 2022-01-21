using System;
using System.Collections.Generic;

public class BinaryTreeZigzagLevelOrderTraversal {
    public BinaryTreeZigzagLevelOrderTraversal() {
        var result = ZigzagLevelOrder(CreateBinaryTree.CreateByIterativeQueue(new int?[] {3,9,20,null,null,15,7}));
        foreach(var list in result)
            Console.Write("["+string.Join(",", list)+"]");
    }
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        List<IList<int>> result = new List<IList<int>>();
        Stack<TreeNode> stackLR = new Stack<TreeNode>();
        Stack<TreeNode> stackRL = new Stack<TreeNode>();
        stackLR.Push(root);
        TreeNode current = null;
        while(stackLR.Count > 0 || stackRL.Count > 0) {
            if(stackLR.Count > 0) {
                result.Add(new List<int>());
                while(stackLR.Count > 0) {
                    current = stackLR.Pop();
                    if(current != null) {
                        result[result.Count - 1].Add(current.val);
                        stackRL.Push(current.left);
                        stackRL.Push(current.right);
                    }
                }
                if(result[result.Count - 1].Count == 0)
                    result.RemoveAt(result.Count - 1);
            }
            if(stackRL.Count > 0) {
                result.Add(new List<int>());
                while(stackRL.Count > 0) {
                    current = stackRL.Pop();
                    if(current != null) {
                        result[result.Count - 1].Add(current.val);
                        stackLR.Push(current.right);
                        stackLR.Push(current.left);
                    }
                }
                if(result[result.Count - 1].Count == 0)
                    result.RemoveAt(result.Count - 1);
            }
        }
        return result;
    } 
}