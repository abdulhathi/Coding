using System;
using System.Collections.Generic;

public class DetectACycleInUDGUsingDFS {
    public DetectACycleInUDGUsingDFS() {
        Dictionary <char, char[]> adjList = new Dictionary <char, char[]>();
        adjList.Add('A', new char[] {'B','F'});
        adjList.Add('B', new char[] {'C','E'});
        adjList.Add('C', new char[] {'D'});
        adjList.Add('D', new char[] {'E'});
        // adjList.Add('E', new char[] {'B'});
        adjList.Add('E', new char[0]);
        HashSet<char> visiting = new HashSet<char>();
        HashSet<char> visited = new HashSet<char>();

        bool cycleExist = false;
        foreach(var vertexU in adjList.Keys)
            if(!visited.Contains(vertexU)) {
                if(DetectCycleUsingDFS(vertexU, adjList, visiting, visited)) {
                    cycleExist = true; 
                    break;
                }
            }
        Console.WriteLine($"Cycle detected is {cycleExist}");
    }
    // Space Complexity : O(V)
    // Time complexity  : O(V+E);
    public bool DetectCycleUsingDFS(char vertexU, Dictionary<char, char[]> adjList, HashSet<char> visiting, HashSet<char> visited) {
        visiting.Add(vertexU);
        foreach(var vertexV in adjList[vertexU]) {
            if(visiting.Contains(vertexV))
                return true;
            if(!visited.Contains(vertexV))
                return DetectCycleUsingDFS(vertexV, adjList, visiting, visited);
        }
        visiting.Remove(vertexU);
        visited.Add(vertexU);
        return false;
    }
}