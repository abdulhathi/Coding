using System;
using System.Collections.Generic;

public class FordFulkersonMaxFlow {
    public FordFulkersonMaxFlow() {
        int[][] graph = { 
            new int[] {'A','B',3}, new int[] {'A','D',3},
            new int[] {'B','C',4},
            new int[] {'C','D',1}, new int[] {'C','E',2},
            new int[] {'D','E',2},
            new int[] {'D','F',6},
            new int[] {'E','G',1},
            new int[] {'F','G',9}
        };
        int flow = MaximumFlow(graph, 'A', 'G');
        Console.WriteLine(flow);
    }
    public int MaximumFlow(int[][] graph, int source, int sink) {
        var adjList = new Dictionary<int, Dictionary<int, int>>();
        var visitParentMap = new Dictionary<int, int?>();
        var queue = new Queue<int>();
        var maxFlow = 0;

        foreach(var edge in graph) {
            if(!adjList.ContainsKey(edge[0]))
                adjList.Add(edge[0], new Dictionary<int, int>());
            if(!adjList.ContainsKey(edge[1]))
                adjList.Add(edge[1], new Dictionary<int, int>());
            adjList[edge[0]].Add(edge[1], edge[2]);
            adjList[edge[1]].Add(edge[0], 0);
        }

        // Find the agumented path until we cannot able to reach source to sink
        while(BFS(source)) {
            // Find the min residual capacity from the path
            int minCapacity = int.MaxValue, current = sink;
            while(visitParentMap[current] != null) {
                minCapacity = Math.Min(adjList[visitParentMap[current].Value][current], minCapacity);
                current = visitParentMap[current].Value;
            }
            current = sink;
            maxFlow += minCapacity;
            while(visitParentMap[current] != null) {
                adjList[visitParentMap[current].Value][current] -= minCapacity;
                adjList[current][visitParentMap[current].Value] += minCapacity;
                current = visitParentMap[current].Value;
            }
        }
        return maxFlow;

        bool BFS(int vertexU) {
            visitParentMap = new Dictionary<int, int?>();
            queue = new Queue<int>();
            visitParentMap.Add(vertexU, null);
            queue.Enqueue(vertexU);
            while(queue.Count > 0) {
                vertexU = queue.Dequeue();
                foreach(var vertexV in adjList[vertexU]) {
                    if(vertexV.Value > 0 && !visitParentMap.ContainsKey(vertexV.Key)) {
                        visitParentMap.Add(vertexV.Key, vertexU);
                        if(vertexV.Key == sink)
                            return true;
                        queue.Enqueue(vertexV.Key);
                    }
                }
            }
            return false;
        }
    }
}