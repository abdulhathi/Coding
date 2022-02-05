using System;
using System.Collections.Generic;

/* Transitive clouser is build the reachability matrix from 
the each vertex of the graph is connected/not connected identification
*/
public class TransitiveClousre {
    /*        0 1 2 3  
             -----------
          0 | 1 1 1 1
          1 | 1 1 1 1
          2 | 1 1 1 1
          3 | 0 0 0 1
    */
    public TransitiveClousre() {
        int noOfVertices = 4;
        var adj = new List<List<int>>();
        adj.Add(new List<int>() { 1,2,3 });
        adj.Add(new List<int>() { 0,2,3 });
        adj.Add(new List<int>() { 0,1,3 });
        adj.Add(new List<int>());
        var matrix = BuildReachabilityMatrix(4, adj);
        for(int r = 0; r < noOfVertices; r++) {
            for(int c = 0; c < noOfVertices; c++) {
                Console.Write(matrix[r,c]+" ");
            }
            Console.WriteLine();
        }
    }
    public int[,] BuildReachabilityMatrix(int V,  List<List<int>> adj) {
        HashSet<int> visited = null;
        int[,] reachableMatrix = new int[V,V];
        for(int i = 0; i < V; i++) {
            visited = new HashSet<int>();
            reachableMatrix[i,i] = 1;
            DFS(i,i);
        }
        void DFS(int vertexU, int vertexRoot) {
            visited.Add(vertexU);
            foreach(var vertexV in adj[vertexU]) {
                if(!visited.Contains(vertexV)) {
                    reachableMatrix[vertexRoot,vertexV] = 1;
                    DFS(vertexV, vertexRoot);
                }
            }
        }
        return reachableMatrix;
    }
}