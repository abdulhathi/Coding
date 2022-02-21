/*                          987. Vertical Order Traversal of a Binary Tree

    Given the root of a binary tree, calculate the vertical order traversal of the binary tree.

    For each node at position (row, col), its left and right children will be at positions (row + 1, col - 1) and (row + 1, col + 1) respectively. The root of the tree is at (0, 0).

    The vertical order traversal of a binary tree is a list of top-to-bottom orderings for each column index starting from the leftmost column and ending on the rightmost column. There may be multiple nodes in the same row and same column. In such a case, sort these nodes by their values.

    Return the vertical order traversal of the binary tree.

    Example 1:
        Input: root = [3,9,20,null,null,15,7]
        Output: [[9],[3,15],[20],[7]]
        Explanation:
        Column -1: Only node 9 is in this column.
        Column 0: Nodes 3 and 15 are in this column in that order from top to bottom.
        Column 1: Only node 20 is in this column.
        Column 2: Only node 7 is in this column.
    Example 2:
        Input: root = [1,2,3,4,5,6,7]
        Output: [[4],[2],[1,5,6],[3],[7]]
        Explanation:
        Column -2: Only node 4 is in this column.
        Column -1: Only node 2 is in this column.
        Column 0: Nodes 1, 5, and 6 are in this column.
                1 is at the top, so it comes first.
                5 and 6 are at the same position (2, 0), so we order them by their value, 5 before 6.
        Column 1: Only node 3 is in this column.
        Column 2: Only node 7 is in this column.
    Example 3:
        Input: root = [1,2,3,4,6,5,7]
        Output: [[4],[2],[1,5,6],[3],[7]]
        Explanation:
        This case is the exact same as example 2, but with nodes 5 and 6 swapped.
        Note that the solution remains the same since 5 and 6 are in the same location and should be ordered by their values.
    Constraints:
        The number of nodes in the tree is in the range [1, 1000].
        0 <= Node.val <= 1000
*/
using System;
using System.Collections.Generic;

public class VerticalOrderTraversalOfABT {
    public VerticalOrderTraversalOfABT() {
        var treeNode = TreeNode.Create(new int?[] {3,9,8,4,0,1,7,null,null,null,2,5});
        var verticalOrder = VerticalTraversal(treeNode);
        foreach(var row in verticalOrder)
            Console.WriteLine(string.Join(",", row));
    }
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        var vertical = new SortedDictionary<int, SortedDictionary<int, List<int>>>();
        var result = new List<IList<int>>();
        PreOrder(root,0, 0);
        foreach(var column in vertical.Values) {
            var list = new List<int>();
            foreach(var row in column)
                list.AddRange(row.Value.OrderBy(x=>x).ToList());
            result.Add(list);
        }
        return result;
        
        void PreOrder(TreeNode root, int col, int row) {
            if(root != null) {
                if(!vertical.ContainsKey(col))
                    vertical.Add(col, new SortedDictionary<int, List<int>>());
                if(!vertical[col].ContainsKey(row))
                    vertical[col].Add(row, new List<int>());
                vertical[col][row].Add(root.val);
                PreOrder(root.left, col - 1, row + 1);
                PreOrder(root.right, col + 1, row + 1);
            }
        }
    }
}