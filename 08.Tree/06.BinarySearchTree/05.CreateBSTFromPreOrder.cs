using System;

public class CreateBSTFromPreOrder {
    public CreateBSTFromPreOrder() {
        int[] preOrder = {4,2,3,1}; //{5,2,6,1,3}; // {30,20,10,15,25,5,40,50,45};
        TreeNode root = CreateBSTFromPreOrderArr(preOrder);
        TreeNode.PrintLevelOrder(root);
        //Console.WriteLine(VerifyPreorder(preOrder));
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
                current.left = new TreeNode(preOrder[i++]);
                stack.Push(current);
                current = current.left;
            }
            else if(preOrder[i] > current.val && preOrder[i] < stack.Peek().val) {
                current.right = new TreeNode(preOrder[i++]);
                current = current.right;
            }
            else
                current = stack.Pop();
        }
        return root;
    }
    public TreeNode CreateBSTFromPreOrderArr(int[] preorder) {
        int min = int.MinValue, max = int.MaxValue, i = 0;
        TreeNode root = new TreeNode(preorder[i++]), current = root;
        Stack<(TreeNode node, int min, int max)> stack = new Stack<(TreeNode node, int min, int max)>();
        while(i < preorder.Length) {
            if(preorder[i] > min && preorder[i] < current.val) {
                current.left = new TreeNode(preorder[i++]);
                stack.Push((current, min, max));
                max = Math.Min(max, current.val);
                current = current.left;
            }
            else if(preorder[i] > current.val && preorder[i] < max) {
                current.right = new TreeNode(preorder[i++]);
                min = Math.Max(current.val, min);
                current = current.right;
            }
            else if(stack.Count > 0) {
                var stackTop = stack.Pop();
                current = stackTop.node;
                min = stackTop.min;
                max = stackTop.max;
            }
            else
                return null;
        }
        return root;
    }
    public bool VerifyPreorder(int[] preorder) {
        if(preorder == null && preorder.Length == 0)
            return true;
        return VerifyPreorder(preorder, int.MinValue, int.MaxValue, preorder[0]);
    }
    int k = 0;
    public bool VerifyPreorder(int[] preorder, int min, int max, int root) {
        if(k >= preorder.Length)
            return true;
        bool left = false, right = false;
        int current = preorder[++k];
        if(current > min && current < root)
            left = VerifyPreorder(preorder, min, root, current);
        else if(current > root && current < max)
            right = VerifyPreorder(preorder, root, max, current);
        return left && right;
    }
}