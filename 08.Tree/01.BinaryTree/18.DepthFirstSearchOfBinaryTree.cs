using System;
using System.Collections.Generic;

/*
                            8
                          /   \             BFS : 8,3,5,12,10,6,4,2,9,7
                         /     \            DFS : 8,3,12,4,9,7,5,10,6,2
                        3       5
                       /       / \
                      12      10  6 
                       \         /   
                        4       2
                       / \  
                      9   7 
*/
public class DepthFirstSearchOfBinaryTree {
    public DepthFirstSearchOfBinaryTree() {
        var root = CreateBinaryTree.CreateByIterativeQueue(new int?[] {8,3,5,12,null,10,6,null,4,null,null,2,null,9,7});
        HashSet<TreeNode> visited = new HashSet<TreeNode>();
        DFS(root, visited);
    }
    public void DFS(TreeNode root, HashSet<TreeNode> visited) {
        if(root != null) {
            Console.Write(root.val+",");
            visited.Add(root);
            if(!visited.Contains(root.left)) 
                DFS(root.left, visited);
            if(!visited.Contains(root.right))
                DFS(root.right, visited);
        }
    }
}