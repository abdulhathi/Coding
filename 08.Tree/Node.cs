// A binary tree Node
public class Node
{
    public int data;
    public Node left;
    public Node right;

    public Node(int key)
    {
        this.data = key;
        this.left = null;
        this.right = null;
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
                    current.left = arr[i].HasValue ? new Node(arr[i].Value) : null;
                    queue.Enqueue(current.left);
                    i++;
                }
                if(arr.Length > i) {
                    current.right = arr[i].HasValue ? new Node(arr[i].Value) : null;
                    queue.Enqueue(current.right);
                    i++;
                }
            }
        }
        return root;
    }
}