using System;
using System.Collections.Generic;

public class PrimsMinimumSpanningTree {
    public PrimsMinimumSpanningTree() {
        List<(char u, char v, int weight)> adjList = new List<(char u, char v, int weight)>();
        adjList.Add(('A','B',3)); adjList.Add(('B','A',3));
        adjList.Add(('A','D',1)); adjList.Add(('D','A',1));
        adjList.Add(('B','D',3)); adjList.Add(('D','B',3));
        adjList.Add(('B','C',1)); adjList.Add(('C','B',1));
        adjList.Add(('C','D',1)); adjList.Add(('D','C',1));
        adjList.Add(('C','E',5)); adjList.Add(('E','C',5));
        adjList.Add(('C','F',4)); adjList.Add(('F','C',4));
        adjList.Add(('D','E',6)); adjList.Add(('E','D',6));
        adjList.Add(('E','F',2)); adjList.Add(('F','E',2));

        Dictionary<char, Dictionary<char, int>> adjList1 = new Dictionary<char, Dictionary<char, int>>();
        foreach(var adj in adjList) {
            if(!adjList1.ContainsKey(adj.u))
                adjList1.Add(adj.u, new Dictionary<char, int>());
            adjList1[adj.u].Add(adj.v, adj.weight);
        }

        PrimsMST('A', adjList1);
    }
    // Space Complexity : O(V)
    // Time Complexity  : O(E * Log V)  "logV is because of using the Heap(sortedSet)
    public void PrimsMST(char source, Dictionary<char, Dictionary<char, int>> adjList) {   
        List<char[]> edges = new List<char[]>();
        Dictionary<char, char[]> parentMap = new Dictionary<char, char[]>();
        //Heap object
        Dictionary<char, int> weightMap = new Dictionary<char, int>();
        SortedSet<(int Weight, char Vertex)> heapSet = new SortedSet<(int Weight, char Vertex)>();
        
        heapSet.Add((0, source));
        foreach(var key in adjList.Keys) {
            weightMap.Add(key, key == source ? 0 : int.MaxValue);
            parentMap.Add(key, null);
        }

        while(heapSet.Count > 0) {
            var min = heapSet.Min;
            heapSet.Remove(min);
            weightMap.Remove(min.Vertex);
            if(parentMap[min.Vertex] != null)
                edges.Add(parentMap[min.Vertex]);
            foreach(var adjVertex in adjList[min.Vertex]) {
                if(weightMap.ContainsKey(adjVertex.Key) && weightMap[adjVertex.Key] > adjVertex.Value) {
                    heapSet.Remove((weightMap[adjVertex.Key], adjVertex.Key));
                    weightMap[adjVertex.Key] = adjVertex.Value;
                    heapSet.Add((adjVertex.Value, adjVertex.Key));
                    parentMap[adjVertex.Key] = new char[] {adjVertex.Key,min.Vertex};
                }
            }
        }
        foreach(var edge in edges)
            Console.Write("({0},{1}),", edge[0], edge[1]);
    }
}