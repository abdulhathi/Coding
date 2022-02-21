/*      236. Lowest Common Ancestor of a Binary Tree

*/
using System;

public class LowestCommonAncestorOfABTIII {
    // Definition for a Node.
    public class Node {
        public int val;
        public Node left;
        public Node right;
        public Node parent;
        public Node(int val=0, Node parent = null, Node left=null, Node right=null) {
            this.val = val;
            this.parent = parent;
            this.left = left;
            this.right = right;
        }
        public Node(int? val = null, int? left = null, int? right = null) {
            this.val = val.Value;
            this.left = left.HasValue ? new Node(left.Value) : null;
            this.right = right.HasValue ? new Node(right.Value) : null;
        }
        public static Node Create(int?[] arr) {
            int i = 0;
            if(arr == null || arr.Length == 0 || arr[i] == null)
                return null;
            Queue<Node> queue = new Queue<Node>();
            Node root = new Node(arr[i++].Value);
            queue.Enqueue(root);
            Node current = null;
            while(queue.Count > 0) {
                current = queue.Dequeue();
                if(current != null) {
                    if(arr.Length > i) {
                        current.left = arr[i].HasValue ? new Node(arr[i].Value, current) : null;
                        queue.Enqueue(current.left);
                        i++;
                    }
                    if(arr.Length > i) {
                        current.right = arr[i].HasValue ? new Node(arr[i].Value, current) : null;
                        queue.Enqueue(current.right);
                        i++;
                    }
                }
            }
            return root;
        }
    }
    public LowestCommonAncestorOfABTIII() {
        var root = Node.Create(new int?[] {3,5,1,6,2,0,8,null,null,7,4});
        var node = LowestCommonAncestor(root.left, root.left.right.right);
        Console.WriteLine(node.val);
    }
    public Node LowestCommonAncestor(Node p, Node q) {
        Stack<Node> pStack = new Stack<Node>();
        Stack<Node> qStack = new Stack<Node>();
        Node lcaNode = null;
        
        while(p != null) {
            pStack.Push(p);
            p = p.parent;
        }
        while(q != null) {
            qStack.Push(q);
            q = q.parent;
        }
        
        while(pStack.Count > 0 && qStack.Count > 0) {
            p = pStack.Pop(); q = qStack.Pop();
            if(p == q)
                lcaNode = p;
        }
        return lcaNode;
    }
}