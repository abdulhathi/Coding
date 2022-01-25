using System;
using System.Collections.Generic;

public class DepthFirstSearchInGraph {
    public DepthFirstSearchInGraph() {
        Dictionary<int, int[]> adjList = new Dictionary<int, int[]>();
        adjList.Add(1, new int[] {2,3,4});
        adjList.Add(2, new int[] {1,3});
        adjList.Add(3, new int[] {1,2,4,5});
        adjList.Add(4, new int[] {1,3,5});
        adjList.Add(5, new int[] {4,3,6,7});
        adjList.Add(6, new int[] {5});
        adjList.Add(7, new int[] {5});

        HashSet<int> visited = new HashSet<int>();
        DFS(5, adjList, visited);
        foreach(var key in adjList.Keys)
            if(!visited.Contains(key))
                DFS(key, adjList, visited);
    }
    public void DFS(int vertexU, Dictionary<int, int[]> adjList, HashSet<int> visited) {
        Console.Write(vertexU+",");
        visited.Add(vertexU);
        foreach(var vertexV in adjList[vertexU]) {
            if(!visited.Contains(vertexV))
                DFS(vertexV, adjList, visited);
        }
    }
}