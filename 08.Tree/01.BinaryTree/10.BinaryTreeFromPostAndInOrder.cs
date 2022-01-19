using System;

public class BinaryTreeFromPostAndInOrder {
    int pos = 0;
    public BinaryTreeFromPostAndInOrder() {
        int[] postOrder = {6,3,9,7,8,5,1,2,4};
        int[] inOrder = {7,6,9,3,4,5,8,2,1};
        pos = postOrder.Length - 1;
        TreeNode result = BTFromPostAndInOrder(postOrder, inOrder, 0, pos);
        TreeNode.PrintLevelOrder(result);
    }
    public TreeNode BTFromPostAndInOrder(int[] postOrder, int[] inOrder, int l, int r) {
        if(l > r) return null;
        TreeNode root = new TreeNode(postOrder[pos--]);
        for(int i = l; i <= r; i++) {
            if(inOrder[i] == root.val) {
                root.right = BTFromPostAndInOrder(postOrder, inOrder, i+1, r);
                root.left = BTFromPostAndInOrder(postOrder, inOrder, l, i-1);
                break;
            }
        }
        return root;
    }
}