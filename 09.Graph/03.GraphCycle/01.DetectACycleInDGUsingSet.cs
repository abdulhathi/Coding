using System;

public class DetectACycleInDG {
    public DetectACycleInDG() {
        Dictionary<int, int[]> adjList = new Dictionary<int, int[]>();
        adjList.Add(1, new int[] {2,3,4});
        adjList.Add(4, new int[] {5});
        adjList.Add(5, new int[] {6});
        // adjList.Add(6, new int[] {4});
        adjList.Add(2, new int[] {3});

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
    public bool DetectCycleInDG(int vertexU, Dictionary<int, int[]> adjList, HashSet<int> visiting, HashSet<int> visited) {
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