using System;

public class DisjointSet<T> {
    public class Node {
        public T Key; 
        public long Rank; 
        public Node Parent;
        public Node(T key, long rank) {
            this.Key = key; this.Rank = rank; 
            this.Parent = this;
        }
    }
    long rank = 0;
    Dictionary<T, Node> set = new Dictionary<T, Node>();
    public void MakeSet(T key) {
        if(!set.ContainsKey(key))
            set.Add(key, new Node(key, rank++));
    }
    public T FindParent(T key) {
        return FindParent(set[key]).Parent.Key;
    }
    private Node FindParent(Node child) {
        if(child == child.Parent)
            return child.Parent;
        child.Parent = FindParent(child.Parent);
        return child.Parent;
    }
    public bool UnionSet(T key1, T key2) {
        Node parent1 = FindParent(set[key1]), parent2 = FindParent(set[key2]);
        if(parent1 == parent2) 
            return false;
        if(parent1.Rank < parent2.Rank) 
            set[key1].Parent = set[key2].Parent = parent2.Parent = parent1;
        else
            set[key1].Parent = set[key2].Parent = parent1.Parent = parent2;
        return true;
    }
}
public class DisjointSetTest {
    public DisjointSetTest() {
        DisjointSet<string> set = new DisjointSet<string>();
        set.MakeSet("Abdul");
        set.MakeSet("Aysha");
        set.MakeSet("Afasr");
        set.MakeSet("Afraz");
        set.MakeSet("Amira");

        Console.WriteLine(set.UnionSet("Abdul","Aysha"));
        Console.WriteLine(set.UnionSet("Abdul","Aysha"));
        Console.WriteLine(set.UnionSet("Afraz","Amira"));
        Console.WriteLine(set.FindParent("Aysha"));
        Console.WriteLine(set.FindParent("Amira"));
        Console.WriteLine(set.UnionSet("Aysha","Amira"));
        Console.WriteLine(set.FindParent("Amira"));
    }
}