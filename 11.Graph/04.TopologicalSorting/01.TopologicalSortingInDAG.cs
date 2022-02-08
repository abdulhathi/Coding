using System;
using System.Collections.Generic;

public class TopologicalSortingInDAG {
    public TopologicalSortingInDAG() {
        Dictionary<char, char[]> adjList = new Dictionary<char, char[]>();
        adjList.Add('A', new char[] {'C'});
        adjList.Add('B', new char[] {'C','D'});
        adjList.Add('C', new char[] {'E'});
        adjList.Add('D', new char[] {'F'});
        adjList.Add('E', new char[] {'H','F'});
        adjList.Add('F', new char[] {'G'});
        HashSet<char> visited = new HashSet<char>();
        Stack<char> sortedStack = new Stack<char>();

        foreach(var vertexU in adjList.Keys) 
            if(!visited.Contains(vertexU))
                DFS_TopologicalSorting(vertexU, adjList, visited, sortedStack);
        while(sortedStack.Count > 0)
            Console.Write(sortedStack.Pop()+",");
    }
    // Space complexity : O(V)
    // Time complexity  : O(V+E)
    public void DFS_TopologicalSorting(char vertexU, Dictionary<char, char[]> adjList, HashSet<char> visited, Stack<char> sortedStack) {
        visited.Add(vertexU);
        if(adjList.ContainsKey(vertexU)) {
            foreach(var vertexV in adjList[vertexU]) {
                if(!visited.Contains(vertexV))
                    DFS_TopologicalSorting(vertexV, adjList, visited, sortedStack);
            }
        }
        sortedStack.Push(vertexU);
    }
}