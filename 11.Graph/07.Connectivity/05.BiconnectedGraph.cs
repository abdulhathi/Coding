/*
    Biconnected Graph
    -----------------
    1. Connected to All vertices
    2. No articulation point.
*/
using System;
using System.Collections.Generic;

public class BiconnectedGraph {
    public BiconnectedGraph() {
        // Console.WriteLine(IsBiconnectedGraph(3, new List<IList<int>>() { new List<int>() {0,1}, new List<int> {1,2} }));

        Console.WriteLine(IsBiconnectedGraph(5, new List<IList<int>>() { 
                new List<int> {1,0}, new List<int> {0,3}, new List<int> {3,4},
                new List<int> {2,0}, new List<int> {2,1}, //new List<int> {4,2} 
            }));
    }
    public bool IsBiconnectedGraph(int n, IList<IList<int>> connections) {
        var adjList = new Dictionary<int, HashSet<int>>();
        for(int i = 0; i < n; i++)
            adjList.Add(i, new HashSet<int>());
        foreach(var conn in connections) {
            adjList[conn[0]].Add(conn[1]);
            adjList[conn[1]].Add(conn[0]);
        }
        bool connected = IsConnectedToAll(n, adjList);
        bool ap = ArticulationPointExist(n, adjList);
        return connected && !ap;
    }
    public bool IsConnectedToAll(int n, Dictionary<int, HashSet<int>> adjList) {
        bool zeroEdges = true;
        for(int i = 0; i < n; i++)
            if(adjList[i].Count > 0)
                zeroEdges = false;
        if(zeroEdges)
            return false;

        var visited = new HashSet<int>();
        
        DFS(n-1);
        return  visited.Count == n - 1;

        void DFS(int vertexU) {
            visited.Add(vertexU);
            foreach(var vertexV in adjList[vertexU]) {
                if(!visited.Contains(vertexV))
                    DFS(vertexV);
            }
        }
    }
    public bool ArticulationPointExist(int n, Dictionary<int, HashSet<int>> adjList) {
        var timeMap = new Dictionary<int, (int VisitTime, int LowTime, int? Parent, int Childs)>();
        var time = 0;

        return DFS(n-1, null);

        bool DFS(int vertexU, int? parent) {
            timeMap.Add(vertexU, (time, time, null, 0));
            time++;
            foreach(var vertexV in adjList[vertexU]) {
                if(parent == null) {
                    var current = timeMap[vertexU];
                    current.Childs++;
                    timeMap[vertexU] = current;
                }
                if(parent != vertexV) {
                    if(!timeMap.ContainsKey(vertexV))
                        if(DFS(vertexV, vertexU))
                            return true;
                    if(timeMap[vertexU].LowTime > timeMap[vertexV].LowTime) {
                        var current = timeMap[vertexU];
                        current.LowTime = timeMap[vertexV].LowTime;
                        timeMap[vertexU] = current;
                    }
                }
                if(timeMap[vertexU].VisitTime <= timeMap[vertexV].LowTime) {
                    if(parent == null)
                        return timeMap[vertexU].Childs > 1 ? true : false;
                    return true;
                }
            }
            return false;
        }
    }
}