using System;
using System.Collections.Generic;

public class HamiltonianCycle {
    public HamiltonianCycle() {
        int[][] graph = { 
            new int[] {1,2}, new int[] {1,3}, new int[] {1,5},
            new int[] {2,3}, new int[] {2,4}, new int[] {2,5},
            new int[] {3,4}, 
            new int[] {4,5}
        };
        var result = AllPossibleHamiltonianCycle(5, graph);
    }
    public List<IList<int>> AllPossibleHamiltonianCycle(int n, int[][] graph) {
        var adjList = new Dictionary<int, HashSet<int>>();
        var visited = new HashSet<int>();

        foreach(var edge in graph) {
            if(!adjList.ContainsKey(edge[0]))
                adjList.Add(edge[0], new HashSet<int>());
            if(!adjList.ContainsKey(edge[1]))
                adjList.Add(edge[1], new HashSet<int>());
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        visited.Add(1);
        DFS(1,1);
        return null;

        void DFS(int vertexU, int source) {
            if(visited.Count == n)
                Console.WriteLine(string.Join(",",visited));
            else {
                for(int i = 2; i < n+1; i++) {
                    // duplicate check
                    if(visited.Contains(i))
                        continue;
                    // checking the edge from the previous vertex
                    if(!adjList[vertexU].Contains(i))
                        continue;
                    // If this is a last vertex then there should be an edge from source vertex
                    if(visited.Count + 1 == n && !adjList[source].Contains(i))
                        continue;
                    
                    visited.Add(i);
                    DFS(i, source);
                    visited.Remove(i);
                }
            }
        }
    }
}