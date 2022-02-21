/*          314. Binary Tree Vertical Order Traversal
    Given the root of a binary tree, return the vertical order traversal of its nodes' values. (i.e., from top to bottom, column by column).
    If two nodes are in the same row and column, the order should be from left to right.

    Example 1:
        Input: root = [3,9,20,null,null,15,7]
        Output: [[9],[3,15],[20],[7]]
    
    Example 2:
        Input: root = [3,9,8,4,0,1,7]
        Output: [[4],[9],[3,0,1],[8],[7]]
    
    Example 3:
        Input: root = [3,9,8,4,0,1,7,null,null,null,2,5]
        Output: [[4],[9,5],[3,0,1],[8,2],[7]]
    
    Constraints:
        The number of nodes in the tree is in the range [0, 100].
        -100 <= Node.val <= 100
 */
public class BinaryTreeVerticalOrderTraversal {
    public BinaryTreeVerticalOrderTraversal() {
        var treeNode = TreeNode.Create(new int?[] {3,9,8,4,0,1,7,null,null,null,2,5});
        var verticalOrder = VerticalOrder(treeNode);
        foreach(var row in verticalOrder)
            Console.WriteLine(string.Join(",", row));
    }
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        var vertical = new SortedDictionary<int, SortedDictionary<int, IList<int>>>();
        var result = new List<IList<int>>();
        PreOrder(root,0, 0);
        foreach(var column in vertical.Values) {
            var list = new List<int>();
            foreach(var row in column.Values)
                list.AddRange(row);
            result.Add(list);
        }
        return result;
        
        void PreOrder(TreeNode root, int col, int row) {
            if(root != null) {
                if(!vertical.ContainsKey(col))
                    vertical.Add(col, new SortedDictionary<int, IList<int>>());
                if(!vertical[col].ContainsKey(row))
                    vertical[col].Add(row, new List<int>());
                vertical[col][row].Add(root.val);
                PreOrder(root.left, col - 1, row + 1);
                PreOrder(root.right, col + 1, row + 1);
            }
        }
    }
    
}