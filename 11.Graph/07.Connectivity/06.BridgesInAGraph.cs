using System;

public class BridgesInAGraph {
    public BridgesInAGraph() {
        // char[][] edges = {
        //     new char[] {'A','B'}, new char[] {'A','C'}, new char[] {'B','C'}, new char[] {'B','D'},
        // };
        char[][] edges = { new char[] {'A','B'}, new char[] {'B','C'} };
        var bridges = FindAllBridgesInGraph('B', edges);
        foreach(var bridge in bridges)
            Console.Write($"({bridge[0]},{bridge[1]}), ");
    }
    public IList<char[]> FindAllBridgesInGraph(char source, char[][] edges) {
        var adjList = new Dictionary<char, HashSet<char>>();
        var timeMap = new Dictionary<char, (int VisitTime, int LowTime, char? Parent)>();
        var bridges = new List<char[]>();
        var time = 0;

        foreach(var edge in edges) {
            if(!adjList.ContainsKey(edge[0]))
                adjList.Add(edge[0], new HashSet<char>());
            if(!adjList.ContainsKey(edge[1]))
                adjList.Add(edge[1], new HashSet<char>());
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        DFS(source, null);
        return bridges;

        void DFS(char vertexU, char? parent) {
            timeMap.Add(vertexU, (time, time, parent));
            time++;
            foreach(var vertexV in adjList[vertexU]) {
                if(parent != vertexV) {
                    if(!timeMap.ContainsKey(vertexV))
                        DFS(vertexV, vertexU);
                    if(timeMap[vertexU].LowTime > timeMap[vertexV].LowTime) {
                        var timeParent = timeMap[vertexU];
                        timeParent.LowTime = timeMap[vertexV].LowTime;
                        timeMap[vertexU] = timeParent;
                    }
                }
                if(timeMap[vertexU].VisitTime < timeMap[vertexV].LowTime) 
                    bridges.Add(new char[] {vertexU, vertexV});
            }
        }
    }
}