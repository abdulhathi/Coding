using System;
using System.Collections.Generic;

public class StronglyConnectedComponents{
    public StronglyConnectedComponents() {
        int[][] edges = {
            new int[] {1,0}, new int[] {0,2}, new int[] {2,1}, new int[] {0,3}, new int[] {3,4}  
        };
        IList<IList<int>> sccs = FindSCCUsingKosarajus(edges);
        Console.WriteLine();
        foreach(var comp in sccs)
            Console.WriteLine(string.Join(",", comp));
    }
    public IList<IList<int>> FindSCCUsingKosarajus(int[][] edges) {
        Dictionary<int, HashSet<int>> adjList1 = new Dictionary<int, HashSet<int>>();
        Dictionary<int, HashSet<int>> adjList2 = new Dictionary<int, HashSet<int>>();
        Stack<int> stack = new Stack<int>();
        HashSet<int> visited = new HashSet<int>();
        List<IList<int>> sccs = new List<IList<int>>();

        foreach(var edge in edges) {
            if(!adjList1.ContainsKey(edge[0])) {
                adjList1.Add(edge[0], new HashSet<int>());
                adjList2.Add(edge[0], new HashSet<int>());
            }
            if(!adjList1.ContainsKey(edge[1])) {
                adjList1.Add(edge[1], new HashSet<int>()); 
                adjList2.Add(edge[1], new HashSet<int>());
            }
            adjList1[edge[0]].Add(edge[1]);               
            adjList2[edge[1]].Add(edge[0]);
        }

        foreach(var vertex in adjList1.Keys)
            if(!visited.Contains(vertex))
                DFS1(vertex);

        void DFS1(int vertexU) {
            visited.Add(vertexU);
            foreach(var vertexV in adjList1[vertexU])
                if(!visited.Contains(vertexV))
                    DFS1(vertexV);
            stack.Push(vertexU);
        }

        visited = new HashSet<int>();
        while(stack.Count > 0) {
            if(!visited.Contains(stack.Peek())) {
                var comp = new List<int>();
                DFS2(stack.Peek(), comp);
                sccs.Add(comp);
            }
            stack.Pop();
        }

        void DFS2(int vertexU, List<int> comp) {
            visited.Add(vertexU);
            foreach(var vertexV in adjList2[vertexU])
                if(!visited.Contains(vertexV))
                    DFS2(vertexV, comp);
            comp.Add(vertexU);
        }
        return sccs;
    }
}