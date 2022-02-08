/*
https://media.geeksforgeeks.org/wp-content/cdn-uploads/gq/2015/06/SCCUndirected.png

    (1)-----(0)     (3)
     |               |
     |               |   
     |               |   
    (2)             (4)
*/
using System;
using System.Collections.Generic;

public class PrintAllConnComponentsInUDG {
    public PrintAllConnComponentsInUDG() {
        int[][] adj = { new int[]{1,0}, new int[]{1,2}, new int[]{3,4} };
        PrintAllConnComps(adj);
    }
    public void PrintAllConnComps(int[][] adj) {
        var adjList = new Dictionary<int, List<int>>();
        var visited = new HashSet<int>();

        foreach(var edge in adj) {
            if(!adjList.ContainsKey(edge[0]))
                adjList.Add(edge[0], new List<int>());
            if(!adjList.ContainsKey(edge[1]))
                adjList.Add(edge[1], new List<int>());
            adjList[edge[0]].Add(edge[1]); 
            adjList[edge[1]].Add(edge[0]);
        }
        foreach(var vertex in adjList.Keys) {
            if(!visited.Contains(vertex)) {
                visited = new HashSet<int>();
                DFS(vertex);
                Console.WriteLine(string.Join(",", visited));
            }
        }

        void DFS(int vertexU) {
            visited.Add(vertexU);
            foreach(var vertexV in adjList[vertexU]) {
                if(!visited.Contains(vertexV))
                    DFS(vertexV);
            }
        }
    }
}