using System;
using System.Collections.Generic;

/*
    Directed Graph
    --------------
      ->(0)-------->(1)                 (0,1)
     |   |           |                  (0,2)
     |   |           |                  (1,2)    
     |   V           |                  (2,0) 
      --(2)<---------                   (2,3)
         |            ----              (3,3)
         |           |    | 
          --------->(3)<--
*/
public class FindAPathBetweenTwoVerticesInDG {
    public FindAPathBetweenTwoVerticesInDG() {
        int[][] edges = {new int[] {4,3},new int[] {1,4},new int[] {4,8},new int[] {1,7},new int[] {6,4},new int[] {4,2},new int[] {7,4},new int[] {4,0},new int[] {0,9},new int[] {5,4}};
        bool isPathExist = FindPathBtwnTwoVertices(edges, 5, 9);
        Console.WriteLine($"Vertex from 5 to 9 path exist ? : {isPathExist}");
    }

    public bool FindPathBtwnTwoVertices(int[][] edges, int sourceU, int destinationV) {
        Dictionary<int, HashSet<int>> adjList = new Dictionary<int, HashSet<int>>();
        HashSet<int> visited  = new HashSet<int>();

        foreach(var edge in edges) {
            if(!adjList.ContainsKey(edge[0]))
                adjList.Add(edge[0], new HashSet<int>());
            if(!adjList.ContainsKey(edge[1]))
                adjList.Add(edge[1], new HashSet<int>());
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        return DFS(sourceU);

        bool DFS(int vertexU) {
            visited.Add(vertexU);
            if(adjList[vertexU].Contains(destinationV))
                return true;
            foreach(var vertexV in adjList[vertexU]) {
                if(!visited.Contains(vertexV))
                    if(!DFS(vertexV))
                        continue;
                    else
                        return true;
            }
            return false;
        }
    }
}
