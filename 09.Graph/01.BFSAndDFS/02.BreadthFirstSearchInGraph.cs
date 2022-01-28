using System;
using System.Collections.Generic;

public class BreadthFirstSearchInGraph {
    public BreadthFirstSearchInGraph() {
        Dictionary<int, int[]> adjList = new Dictionary<int, int[]>();
        adjList.Add(1, new int[] {2,3,4});
        adjList.Add(2, new int[] {1,3});
        adjList.Add(3, new int[] {1,2,4,5});
        adjList.Add(4, new int[] {1,3,5});
        adjList.Add(5, new int[] {4,3,6,7});
        adjList.Add(6, new int[0]);
        adjList.Add(7, new int[0]);
        BFS(1, adjList, new HashSet<int>());
    }
    // Space complexity : O(n);
    // Time complexity  : O([V] + [E]) = O(n)
    public void BFS(int vertexU, Dictionary<int, int[]> adjList, HashSet<int> visited) {
        Queue<int> queue = new Queue<int>();
        Console.Write(vertexU+",");
        visited.Add(vertexU);
        queue.Enqueue(vertexU);
        while(queue.Count > 0) {
            vertexU = queue.Dequeue();
            foreach(var vertexV in adjList[vertexU]) {
                if(!visited.Contains(vertexV)) {
                    Console.Write(vertexV+",");
                    visited.Add(vertexV);
                    queue.Enqueue(vertexV);
                }
            }
        }
    }
}