using System;
using System.Collections.Generic;

public class FindIfPathExistsInGraph {
    public FindIfPathExistsInGraph() {
        int[][] edges = new int[][] { new int[]{0,1}, new int[]{1,2}, new int[]{2,0} };
        bool isValid = ValidPath(3, edges, 0, 2);
        Console.WriteLine(isValid);
    }

    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        Dictionary<int, HashSet<int>> adjList = new Dictionary<int, HashSet<int>>();
        for(int i = 0; i < n; i++) {
            adjList.Add(i, new HashSet<int>());
            adjList[i].Add(i);
        }
        foreach(var edge in edges) {
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        
        return DFS(source, adjList, destination);
    }
    public bool DFS(int vertexU, Dictionary<int, HashSet<int>> adjList, int destination) {
        HashSet<int> visited = new HashSet<int>();
        Stack<int> stack = new Stack<int>();
        visited.Add(vertexU);
        stack.Push(vertexU);
        bool noUnvisitedVertex = true;
        while(stack.Count > 0) {
            noUnvisitedVertex = true;
            vertexU = stack.Peek();
            foreach(var vertexV in adjList[vertexU]) {
                if(vertexV == destination)
                    return true;
                if(!visited.Contains(vertexV)) {
                    visited.Add(vertexV);
                    stack.Push(vertexV);
                    noUnvisitedVertex = false;
                    break;
                }
            }
            if(noUnvisitedVertex)
                stack.Pop();
        }
        return false;
    }
}