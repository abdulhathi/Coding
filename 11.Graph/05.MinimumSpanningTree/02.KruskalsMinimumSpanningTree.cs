using System;

public class KruskalsMinimumSpanningTree {
    public KruskalsMinimumSpanningTree() {
        List<(char u, char v, int weight)> adjList = new List<(char u, char v, int weight)>();
        adjList.Add(('A','B',3)); 
        adjList.Add(('A','D',1)); 
        adjList.Add(('B','D',3)); 
        adjList.Add(('B','C',1)); 
        adjList.Add(('C','D',1)); 
        adjList.Add(('C','E',5)); 
        adjList.Add(('C','F',4)); 
        adjList.Add(('D','E',6)); 
        adjList.Add(('E','F',2)); 

        KruskalsMST('A', adjList);
    }
    // Space complexity : O(E+V) 
    // Time complexity  : O(E LogV)
    public void KruskalsMST(char source, List<(char u, char v, int weight)> adjList) {
        SortedSet<(int weight, char u, char v)> sortedSet = new SortedSet<(int weight, char u, char v)>();
        DisjointSet<char> disjointSet = new DisjointSet<char>();
        foreach(var edge in adjList) {
            sortedSet.Add((edge.weight, edge.u, edge.v));
            disjointSet.MakeSet(edge.u);
            disjointSet.MakeSet(edge.v);
        }

        while(sortedSet.Count > 0) {
            var min = sortedSet.Min;
            sortedSet.Remove(min);
            if(disjointSet.UnionSet(min.u, min.v))
                Console.WriteLine($"({min.u},{min.v})-{min.weight}");
        }
    }
}