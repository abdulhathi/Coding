using System;

public class BinaryTreeFromPreAndInOrder {
    public BinaryTreeFromPreAndInOrder() {
        TreeNode result = BTByPreAndInOrder(new int[]{4,7,9,6,3,2,5,8,1},new int[]{7,6,9,3,4,5,8,2,1},0,8);
        TreeNode.PrintLevelOrder(result);
    }
    int pos = 0;
    public TreeNode BTByPreAndInOrder(int[] preOrder, int[] inOrder, int l,int r) {
        if(l > r) return null;
        TreeNode root = new TreeNode(preOrder[pos++]);
        for(int i = l; i <= r; i++) {
            if(inOrder[i] == root.val) {
                root.left = BTByPreAndInOrder(preOrder, inOrder, l, i-1);
                root.right = BTByPreAndInOrder(preOrder, inOrder, i+1, r);
                break;
            }
        }
        return root;
    }
}