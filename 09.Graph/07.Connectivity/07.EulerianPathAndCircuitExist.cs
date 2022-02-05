using System;

/*
    Eulerian Path: This is path traverse and visit all the edges only one time to finish at the end of the vertex
    Eulerian Circuit : This is the traversal to visit all edges only one time to finish at the root vertex
    Eulerian Graph : If the graph it contains a eulerian circuit its called Eulerian graph.

         (1)------(0)------(3)
          |      /   \      |
          |     /     \     |
          |    /       \    |
          |   /         \   |
          |  /           \  |
          (2)             (4)  
*/
public class EulerianPathAndCircuit {
    public EulerianPathAndCircuit() {
        var adj = new List<List<int>>();
        for(int i = 0; i < 5; i++)
            adj.Add(new List<int>());
        adj[0].AddRange(new int[] {1,3,4});
        adj[1].AddRange(new int[] {0,2});
        adj[2].AddRange(new int[] {1});
        adj[3].AddRange(new int[] {0,4});
        adj[4].AddRange(new int[] {0,3});
        EulerianPathExist(5, adj);
    }

    public void EulerianPathExist(int V, List<List<int>> adj) {
        int outDegreeOddCount = 0;
        if(IsConnected(V, adj))
            for(int i = 0; i < V; i++) {
                if((adj[i].Count & 1) > 0)
                    outDegreeOddCount++;
            }
        else 
            Console.WriteLine("This graph is not a Eulerian graph");

        if(outDegreeOddCount == 0)
            Console.WriteLine("This graph is Eulerian graph");
        else if(outDegreeOddCount == 2)
            Console.WriteLine("This graph is Sem-Eulerian graph");
        else
            Console.WriteLine("This graph is not a Eulerian graph");
        
    }
    public bool IsConnected(int V, List<List<int>> adj) {
        int edgeHavingVertex = -1;
        for(int i = 0; i < V; i++) {
            if(adj[i].Count > 0) {
                edgeHavingVertex = i;
                break;
            }
        }
        if(edgeHavingVertex == -1)
            return true;
            
        var visited = new HashSet<int>();

        DFS(edgeHavingVertex);
        
        for(int i = 0; i < V; i++) {
            if(!visited.Contains(i) && adj[i].Count > 0)
                return false;
        }
        return true;

        void DFS(int vertexU) {
            visited.Add(vertexU);
            foreach(var vertexV in adj[vertexU]) {
                if(!visited.Contains(vertexV))
                    DFS(vertexV);
            }
        }
    }
}