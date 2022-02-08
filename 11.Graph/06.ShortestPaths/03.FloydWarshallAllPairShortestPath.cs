using System;
using System.Collections.Generic;

public class FloydWarshallAllPairShortestPath {
    public FloydWarshallAllPairShortestPath() {
        int[][] edges = { 
            new int[]{1,2,3}, new int[]{1,4,7}, 
            new int[]{2,1,8}, new int[]{2,3,2},
            new int[]{3,1,5}, new int[]{3,4,1}, 
            new int[]{4,1,2}
        };
        FloydWarshallAlgo(edges);
    }
    public void FloydWarshallAlgo(int[][] edges) {
        Dictionary<int, Dictionary<int, int>> adjList = new Dictionary<int, Dictionary<int, int>>();
        foreach(var edge in edges) {
            if(!adjList.ContainsKey(edge[0]))
                adjList.Add(edge[0], new Dictionary<int, int>());
            if(!adjList.ContainsKey(edge[1]))
                adjList.Add(edge[1], new Dictionary<int, int>());
            adjList[edge[0]].Add(edge[1], edge[2]);
        }
        foreach(int key in adjList.Keys) {
            if(!adjList[key].ContainsKey(key))
                adjList[key].Add(key,0);
            adjList[key][key] = 0;
        }

        int infinity = int.MaxValue;
        foreach(int vertexMid in adjList.Keys) {
            foreach(int vertexU in adjList.Keys) {
                foreach(int vertexV in adjList.Keys) {
                    if(!adjList[vertexU].ContainsKey(vertexV))
                        adjList[vertexU][vertexV] = infinity;
                    if(vertexU != vertexV && vertexU != vertexMid && vertexV != vertexMid) {
                        if(adjList[vertexU][vertexMid] != infinity && adjList[vertexMid][vertexV] != infinity)
                            adjList[vertexU][vertexV] = Math.Min(adjList[vertexU][vertexV], adjList[vertexU][vertexMid]+adjList[vertexMid][vertexV]);
                    }
                }
            }
        }

        foreach(int vertexU in adjList.Keys) {
            Console.WriteLine();
            foreach(int vertexV in adjList.Keys)
                Console.Write($"({vertexU},{vertexV}) - {adjList[vertexU][vertexV]} ");
        }
    }
}