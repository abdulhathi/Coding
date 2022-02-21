/*                      333. Largest BST Subtree
    Given the root of a binary tree, find the largest subtree, which is also a Binary Search Tree (BST), where the largest means subtree has the largest number of nodes.

    A Binary Search Tree (BST) is a tree in which all the nodes follow the below-mentioned properties:

    The left subtree values are less than the value of their parent (root) node's value.
    The right subtree values are greater than the value of their parent (root) node's value.
    Note: A subtree must include all of its descendants.

    Example 1:
        Input: root = [10,5,15,1,8,null,7]
        Output: 3
        Explanation: The Largest BST Subtree in this case is the highlighted one. The return value is the subtree's size, which is 3.
    Example 2:
        Input: root = [4,2,7,2,3,5,null,2,null,null,null,null,null,1]
        Output: 2
    Constraints:
        The number of nodes in the tree is in the range [0, 104].
        -104 <= Node.val <= 104
    Follow up: 
        Can you figure out ways to solve it with O(n) time complexity?
*/
using System;

public class LargestBSTSubtree {
    public class BSTNode {
        public bool IsBST;
        public int NodeCount; 
        public int Min = int.MaxValue; 
        public int Max = int.MinValue;
        public BSTNode(bool isBST = false) { 
            this.IsBST = isBST;
        }
    }
    public LargestBSTSubtree() {
        TreeNode root = TreeNode.Create(new int?[] {4,2,7,2,3,5,null,2,null,null,null,null,null,1});
        int count = CountLargestBSTSubtree(root);
        Console.WriteLine(count);
    }
    public int CountLargestBSTSubtree(TreeNode root) {
        return PostOrder(root).NodeCount;
        // Postorder
        BSTNode PostOrder(TreeNode root) {
            if(root == null)
                return new BSTNode(true);
            var left = PostOrder(root.left);
            var right = PostOrder(root.right);
            var current = new BSTNode(left.IsBST && right.IsBST);
            if(current.IsBST)
                current.IsBST = (root.val > left.Max && root.val < right.Min);
            if(current.IsBST) {
                current.Min = Math.Min(left.Min, root.val);
                current.Max = Math.Max(right.Max, root.val);
            }
            current.NodeCount = current.IsBST ? left.NodeCount+right.NodeCount+1 : 
                Math.Max(left.NodeCount, right.NodeCount);
            return current;
        }
    }
}