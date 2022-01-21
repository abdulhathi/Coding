using System;

public class CreateBSTFromPreOrder {
    public CreateBSTFromPreOrder() {
        int[] preOrder = {30,20,10,15,25,5,40,50,45};
        TreeNode root = CreateBST(preOrder);
        TreeNode.PrintLevelOrder(root);
    }
    public TreeNode CreateBST(int[] preOrder) {
        if(preOrder == null || preOrder.Length == 0)
            return null;
        TreeNode root = new TreeNode(preOrder[0]);
        TreeNode current = root;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(new TreeNode(int.MaxValue));
        int i = 1;
        while(i < preOrder.Length) {
            if(preOrder[i] < current.val) {
                if(current.left == null)
                    current.left = new TreeNode(preOrder[i++]);
                stack.Push(current);
                current = current.left;
            }
            else if(preOrder[i] > current.val && preOrder[i] < stack.Peek().val) {
                if(current.right == null)
                    current.right = new TreeNode(preOrder[i++]);
                current = current.right;
            }
            else
                current = stack.Pop();
        }
        return root;
    }
}