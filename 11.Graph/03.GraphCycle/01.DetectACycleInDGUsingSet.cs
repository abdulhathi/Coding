using System;

public class DetectACycleInDG {
    public DetectACycleInDG() {
        Dictionary<int, HashSet<int>> adjList = new Dictionary<int, HashSet<int>>();
        // adjList.Add(1, new int[] {2,3,4});
        // adjList.Add(4, new int[] {5});
        // adjList.Add(5, new int[] {6});
        // adjList.Add(2, new int[] {3});
        for(int i = 0; i < 4; i++)
            adjList.Add(i, new HashSet<int>());
        adjList[0].Add(1); adjList[1].Add(2); adjList[2].Add(3); adjList[3].Add(3);

        HashSet<int> visiting = new HashSet<int>();       
        HashSet<int> visited = new HashSet<int>();
        bool cycleExist = false;
        foreach(var vertexU in adjList.Keys) {
            if(!visited.Contains(vertexU))
                cycleExist = DetectCycleInDG(vertexU, adjList, visiting, visited);
        }
        Console.WriteLine($"Cycle exist is {cycleExist}");
    }
    // Time Complexity  : O(V+E)
    // Space Complexity : O(V)
    public bool DetectCycleInDG(int vertexU, Dictionary<int, HashSet<int>> adjList, HashSet<int> visiting, HashSet<int> visited) {
        visiting.Add(vertexU);
        if(adjList.ContainsKey(vertexU)) {
            foreach(var vertexV in adjList[vertexU]) {
                if(visiting.Contains(vertexV))
                    return true;
                if(!visited.Contains(vertexV))
                    return DetectCycleInDG(vertexV, adjList, visiting, visited);
            }
        }
        visited.Add(vertexU);
        visiting.Remove(vertexU);
        return false;
    }
}