using System;
using System.Collections.Generic;

public class DepthFirstSearchInGraph {
    public DepthFirstSearchInGraph() {
        Dictionary<int, int[]> adjList = new Dictionary<int, int[]>();
        adjList.Add(1, new int[] {2,3,4});
        adjList.Add(2, new int[] {1,3});
        adjList.Add(3, new int[] {1,2,4,5});
        adjList.Add(4, new int[] {1,3,5});
        adjList.Add(5, new int[] {4,3,6,7});
        adjList.Add(6, new int[] {5});
        adjList.Add(7, new int[] {5});

        HashSet<int> visited = new HashSet<int>();
        Console.WriteLine();
        DFS(5, adjList, visited);
        Console.WriteLine();
        DFSInIterative(5, adjList);
    }
    // Space complexity : O(n)
    // Time complexity  : O(V + E) = O(n)
    public void DFS(int vertexU, Dictionary<int, int[]> adjList, HashSet<int> visited) {
        Console.Write(vertexU+",");
        visited.Add(vertexU);
        foreach(var vertexV in adjList[vertexU]) {
            if(!visited.Contains(vertexV))
                DFS(vertexV, adjList, visited);
        }
    }
    public void DFSInIterative(int vertexU, Dictionary<int, int[]> adjList) {
        HashSet<int> visited = new HashSet<int>();
        Stack<int> stack = new Stack<int>();
        Console.Write(vertexU+",");
        stack.Push(vertexU);
        visited.Add(vertexU); bool noUnVisited = true;
        while(stack.Count > 0) {
            vertexU = stack.Peek();
            noUnVisited = true;
            foreach(var vertexV in adjList[vertexU]) {
                if(!visited.Contains(vertexV)) {
                    Console.Write(vertexV+",");
                    stack.Push(vertexV);
                    visited.Add(vertexV);
                    noUnVisited = false;
                    break;
                }
            }
            if(noUnVisited)
                stack.Pop();
        }
    }
}