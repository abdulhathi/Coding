using System;
using System.Collections.Generic;

public class MultistageGraph {
    static int INF = int.MaxValue;
    public MultistageGraph() {
        int[,] graph = {
           {INF, 1, 2, 5, INF, INF, INF, INF},
           {INF, INF, INF, INF, 4, 11, INF, INF},
           {INF, INF, INF, INF, 9, 5, 16, INF},
           {INF, INF, INF, INF, INF, INF, 2, INF},
           {INF, INF, INF, INF, INF, INF, INF, 18},
           {INF, INF, INF, INF, INF, INF, INF, 13},
           {INF, INF, INF, INF, INF, INF, INF, 2}
        };
        Console.WriteLine(FindMinCostInMultistageGraph(8, graph));
    }
    public int FindMinCostInMultistageGraph(int n, int[,] graph)
    {
        var adjList = new Dictionary<int, Dictionary<int, int>>();
        var costMap = new Dictionary<int, int>();
        var destinationMap = new Dictionary<int, int>();
        for(int i = 0; i < n; i++) {
            adjList.Add(i, new Dictionary<int, int>());
            costMap.Add(i, INF);
            destinationMap.Add(i, 0);
        }

        for(int r = 0; r < graph.GetLength(0); r++) {
            for(int c = 0; c < graph.GetLength(1); c++) {
                if(graph[r,c] != INF) 
                    adjList[r][c] = graph[r,c];
            }
        }
        destinationMap[n-1] = n-1;
        costMap[n-1] = 0;
        for(int i = n-2; i >= 0; i--) {
            foreach(var adjVertex in adjList[i]) {
                if(adjVertex.Value + costMap[adjVertex.Key] < costMap[i]) {
                    costMap[i] = adjVertex.Value + costMap[adjVertex.Key];
                    destinationMap[i] = adjVertex.Key;
                }
            }
        }
        return costMap[0];
    }
}