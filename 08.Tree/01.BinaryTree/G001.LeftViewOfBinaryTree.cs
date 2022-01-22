using System;

public class LeftViewOfBinaryTree {
    /*              1
                  /   \
                 2     3
                  \     \
                   5     4 
    */
    public LeftViewOfBinaryTree() {
        Node tree = Node.Create(new int?[] {1,2,3,null,5,null,4});
        List<int> leftSideView = leftView(tree);
        Console.WriteLine(string.Join(",", leftSideView));
    }
    public List<int> leftView(Node root)
    {
        List<int> list = new List<int>();
        if(root == null)
            return list;
        Queue<Node> queue = new Queue<Node>();
        list.Add(root.data);
        queue.Enqueue(root);
        queue.Enqueue(null);
        Node current = null;
        while(queue.Count > 0) {
            current = queue.Dequeue();
            if(current != null) {
                if(current.left != null) queue.Enqueue(current.left);
                if(current.right != null) queue.Enqueue(current.right);
            }
            else {
                if(queue.Count > 0) {
                    list.Add(queue.Peek().data);
                    queue.Enqueue(null);
                }
            }
        }
        return list;
    }
}