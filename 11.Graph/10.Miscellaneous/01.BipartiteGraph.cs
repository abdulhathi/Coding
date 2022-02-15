using System;
using System.Collections.Generic;

public class BipartiteGraph {
    public enum GraphColor { NoColor = -1, Red = 0, Green = 1 }
    public BipartiteGraph() {
        int[][] graph = { new int[] {1,2}, new int[] {1,3}, new int[] {2,4} };
        bool isBipartite = CheckTheGraphIsBipartiteOrNot(graph);
        Console.WriteLine(isBipartite);
    }
    public bool CheckTheGraphIsBipartiteOrNot(int[][] graph) {
        var adjList = new Dictionary<int, List<int>>();
        var redSet = new HashSet<int>();
        var greenSet = new HashSet<int>();
        var visited = new HashSet<int>();
        int source = graph[0][0];
        var color = GraphColor.Red;
        
        foreach(var edge in graph) {
            if(!adjList.ContainsKey(edge[0]))
                adjList.Add(edge[0], new List<int>());
            if(!adjList.ContainsKey(edge[1]))
                adjList.Add(edge[1], new List<int>());
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }


        Queue<int> queue = new Queue<int>();
        redSet.Add(source);
        queue.Enqueue(source);
        while(queue.Count > 0) {
            int current = queue.Dequeue();
            color = redSet.Contains(current) ? GraphColor.Red : GraphColor.Green;
            foreach(var adjV in adjList[current]) {
                var adjVColor = (redSet.Contains(adjV) ? GraphColor.Red : 
                                                (greenSet.Contains(adjV) ? GraphColor.Green : GraphColor.NoColor));
                if(adjVColor == color)
                    return false;
                if(visited.Contains(adjV))
                    continue;
                if(color == GraphColor.Red)
                    greenSet.Add(adjV);
                else
                    redSet.Add(adjV);
                visited.Add(adjV);
                queue.Enqueue(adjV);
            }
        }
        return true;
    }
}