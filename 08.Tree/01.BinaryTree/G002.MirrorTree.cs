using System;

public class MirrorTree {
    public MirrorTree() {
        var root  = new Node(1, new Node(2), new Node(3));
        Mirror(root);
        Node.Print(root);
    }
    public void Mirror(Node root)
    {
        Node p = null;
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        while(queue.Count > 0) {
            p = queue.Dequeue();
            if(p != null) {
                queue.Enqueue(p.left);
                queue.Enqueue(p.right);
                var temp = p.right;
                p.right = p.left;
                p.left = temp;
            }
        }
    }
}