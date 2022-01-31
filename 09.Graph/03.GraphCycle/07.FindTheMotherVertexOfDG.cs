using System;
using System.Collections.Generic;

public class FindTheMotherVertexOfDG {
    public FindTheMotherVertexOfDG() {
        /*
                9 22
                0 1
                0 3
                0 4
                0 5
                0 7
                0 8
                1 4
                1 6
                2 3
                2 4
                2 5
                2 6
                2 7
                3 5
                3 7
                3 8
                4 5
                4 6
                4 8
                5 6
                5 8
                6 8
        */
        List<List<int>> adj = new List<List<int>>();
        adj.Add(new List<int>() {1,3,4,5,7,8});
        adj.Add(new List<int>() {4,6});
        adj.Add(new List<int>() {3,4,5,6,7});
        adj.Add(new List<int>() {5,7,8});
        adj.Add(new List<int>() {5,6,8});
        adj.Add(new List<int>() {6,8});
        adj.Add(new List<int>() {8});
        adj.Add(new List<int>());
        adj.Add(new List<int>());
        Console.WriteLine(FindMotherVertex(9, adj));
        // TestCaseRun();
    }
    public void TestCaseRun() {
        int[][] edges1 = { 
            new int[]{0,2}, new int[]{0,1}, 
            new int[]{1,2}, 
            new int[]{4,1},
            new int[]{5,2}, new int[]{5,6},
            new int[]{6,4}, new int[]{6,0},
        };
        Console.WriteLine("TestCase 1 : "+ FindMotherVertex(edges1));
        int[][] edges2 = { 
            new int[] {0,3},
            new int[] {1,4},
            new int[] {2,0}, new int[] {2,1}, 
            new int[] {3,1},
            new int[] {4,3}, new int[] {4,5},
        };
        Console.WriteLine("TestCase 2 : "+ FindMotherVertex(edges2));
    }
    public int FindMotherVertex(int[][] edges) {
        var adjList = new Dictionary<int, HashSet<int>>();
        var vertexMap = new Dictionary<int, int>();
        int maxReachable = 0, maxReachableVertex = 0;

        foreach(var edge in edges) {
            if(!adjList.ContainsKey(edge[0]))
                adjList.Add(edge[0], new HashSet<int>());
            if(!adjList.ContainsKey(edge[1]))
                adjList.Add(edge[1], new HashSet<int>());
            adjList[edge[0]].Add(edge[1]);

            if(maxReachable < adjList[edge[0]].Count) {
                maxReachable = adjList[edge[0]].Count;
                maxReachableVertex = edge[0];
            }
        }
        
        foreach(var vertex in adjList.Keys) {
            if(!vertexMap.ContainsKey(vertex)) {
                vertexMap = new Dictionary<int, int>();
                DFS(vertex, vertex);
                if(maxReachable < vertexMap[vertex]) {
                    maxReachable = vertexMap[vertex];
                    maxReachableVertex = vertex;
                }
            }
        }
        void DFS(int vertexU, int vertexRoot) {
            vertexMap.Add(vertexU, 0);
            foreach(var vertexV in adjList[vertexU]) {
                if(!vertexMap.ContainsKey(vertexV)) {
                    vertexMap[vertexRoot]++;
                    DFS(vertexV, vertexRoot);
                }
            }
        }
        return vertexMap[maxReachableVertex] == adjList.Count - 1 ? maxReachableVertex : -1;
    }

    public int FindMotherVertex(int V, List<List<int>> adj)
    {
        var vertexMap = new Dictionary<int, int>();
        int maxReachable = 1, maxReachableVertex = -1;
        
        for(int i = 0; i < V; i++) {
            if(!vertexMap.ContainsKey(i)) {
                DFS(i, i, adj, vertexMap);
                if(maxReachable < vertexMap[i]) {
                    maxReachable = vertexMap[i];
                    maxReachableVertex = i;
                }
            }
        }

        return vertexMap[maxReachableVertex] == V ? maxReachableVertex : -1;
    }
    void DFS(int vertexU, int vertexRoot, List<List<int>> adj,
    Dictionary<int, int> vertexMap) {
        vertexMap.Add(vertexU, 0);
        foreach(var vertexV in adj[vertexU]) {
            if(!vertexMap.ContainsKey(vertexV)) {
                vertexMap[vertexRoot]++;
                DFS(vertexV, vertexRoot, adj, vertexMap);
            }
        }
    }
}