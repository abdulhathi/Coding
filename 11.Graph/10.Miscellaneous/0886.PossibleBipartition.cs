using System;
using System.Collections.Generic;

public class PossibleBipartition {
    public enum GraphColor { NoColor = -1, Red = 0, Green = 1 }
    public PossibleBipartition() {
        int[][] graph = { new int[] {1,2}, new int[] {1,3}, new int[] {2,4} };
        bool isBipartite = PossibleBipartitionResult(4, graph);
        Console.WriteLine(isBipartite);
    }
    public bool PossibleBipartitionResult(int n, int[][] dislikes) {
        if(dislikes.Length == 0) return true;
        var adjList = new Dictionary<int, List<int>>();
        var redSet = new HashSet<int>();
        var greenSet = new HashSet<int>();
        var visited = new HashSet<int>();
        var color = GraphColor.Red;
        
        foreach(var edge in dislikes) {
            if(!adjList.ContainsKey(edge[0]))
                adjList.Add(edge[0], new List<int>());
            if(!adjList.ContainsKey(edge[1]))
                adjList.Add(edge[1], new List<int>());
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        foreach(var v in adjList.Keys)
            if(!visited.Contains(v))
                if(BFS(v) == false)
                    return false;
        return true;

        bool BFS(int vertesU){
            Queue<int> queue = new Queue<int>();
            redSet.Add(vertesU);
            queue.Enqueue(vertesU);
            while(queue.Count > 0) {
                vertesU = queue.Dequeue();
                color = redSet.Contains(vertesU) ? GraphColor.Red : GraphColor.Green;
                foreach(var adjV in adjList[vertesU]) {
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
}