using System;

public class ConstructBSTFromPreorder {
    public ConstructBSTFromPreorder() {
        int[] preOrder = {30,20,10,15,25,5,40,50,45};
        TreeNode root = BstFromPreorder(preOrder);
        TreeNode.PrintPostOrder(root);
    }
    public TreeNode BstFromPreorder(int[] preorder) {
        if(preorder == null || preorder.Length == 0)
            return null;
        int i = 0;
        TreeNode root = new TreeNode(preorder[i++]);
        TreeNode current = root;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(new TreeNode(int.MaxValue));
        while(i < preorder.Length) {
            if(preorder[i] < current.val) {
                current.left = new TreeNode(preorder[i++]);
                stack.Push(current);
                current = current.left;
            }
            else if(preorder[i] > current.val && preorder[i] < stack.Peek().val) {
                current.right = new TreeNode(preorder[i++]);
                current = current.right;
            }
            else
                current = stack.Pop();
        }
        return root;
    }
}