/*
    Hello, can someone comment, the questions which use "Articulation points" or "bridges" thanks

    https://leetcode.com/problems/critical-connections-in-a-network/
    https://leetcode.com/problems/minimize-malware-spread/
    https://leetcode.com/problems/minimize-malware-spread-ii/
    https://leetcode.com/problems/minimum-number-of-days-to-disconnect-island/
*/
using System;
using System.Collections.Generic;

public class ArticulationPointOrCutVerticesInUDG {
    public ArticulationPointOrCutVerticesInUDG() {
        // char[][] edges = {
        //     new char[] {'A','B'}, new char[] {'B','C'}, new char[] {'C','D'}, 
        //     new char[] {'A','C'}, new char[] {'D','E'}, new char[] {'E','G'}, 
        //     new char[] {'E','F'}, new char[] {'G','F'}, new char[] {'F','H'},
        // };
        char[][] edges = { new char[] {'A','B'}, new char[] {'B','C'} };

        var result = FindAPs('B', edges);
        Console.WriteLine(string.Join(",", result));
    }

    public HashSet<char> FindAPs(char source, char[][] edges) {
        var adjList = new Dictionary<char, HashSet<char>>();
        var timeMap = new Dictionary<char, (int VisitTime, int LowTime, char? Parent, int ChildCount)>();
        var aps  = new HashSet<char>();
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

        void DFS(char vertexU, char? parent) {
            timeMap.Add(vertexU, (time, time, parent, 0));
            time++;
            foreach(var vertexV in adjList[vertexU]) {
                if(timeMap[vertexU].Parent == null) {
                    var u = timeMap[vertexU];
                    u.ChildCount++;
                    timeMap[vertexU] = u;
                }
                if(vertexV != parent) {
                    if(!timeMap.ContainsKey(vertexV))
                        DFS(vertexV, vertexU);
                    if(timeMap[vertexU].LowTime > timeMap[vertexV].LowTime) {
                        var u = timeMap[vertexU];
                        u.LowTime = timeMap[vertexV].LowTime;
                        timeMap[vertexU] = u;
                    }
                }
                if(timeMap[vertexU].VisitTime <= timeMap[vertexV].LowTime) {
                    if(parent == null && timeMap[vertexU].ChildCount <= 1)
                        continue;
                    aps.Add(vertexU);
                }
            }
        }

        return aps;
    }
}