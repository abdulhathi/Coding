using System;

public class CreateBSTFromPostOrder {
    public CreateBSTFromPostOrder() {
        int[] postorder = {15,10,25,20,45,50,40,30};
        TreeNode root = BSTFromPostOrder(postorder);
        TreeNode.PrintLevelOrder(root);
    }
    public TreeNode BSTFromPostOrder(int[] postorder) {
        if(postorder == null || postorder.Length == 0)
            return null;
        int i = postorder.Length - 1;
        TreeNode root = new TreeNode(postorder[i--]);
        TreeNode current = root;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(new TreeNode(int.MinValue));
        while(i >= 0) {
            if(postorder[i] < current.val && postorder[i] > stack.Peek().val) {
                current.left = new TreeNode(postorder[i--]);
                current = current.left;
            }
            else if(postorder[i] > current.val) {
                current.right = new TreeNode(postorder[i--]);
                stack.Push(current);
                current = current.right;
            }
            else
                current = stack.Pop();
        }
        return root;
    }
}