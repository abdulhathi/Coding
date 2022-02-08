using System;
using System.Collections.Generic;

public class ConnectingCitiesWithMinCost {
    public ConnectingCitiesWithMinCost() {
        
        int[][] connections = { new int[]{1,2,5}, new int[]{1,3,6}, new int[]{2,3,1} };
        Console.WriteLine(KruskalsMethod(3, connections)); 
    }
    public int KruskalsMethod(int n, int[][] connections) {
        var adjList = new Dictionary<int, List<int>>();
        var costMap = new Dictionary<int, int>();
        var heapSet = new SortedSet<(int Cost, int City)>();
        var disjointSet = new DisjointSet();

        for(int i = 1; i <= n; i++) {
            adjList.Add(i, new List<int>());
            costMap.Add(i, int.MaxValue);
            disjointSet.MakeSet(i);
        }
        foreach(var conn in connections) {
            adjList[conn[0]].Add(conn[1]);
            adjList[conn[1]].Add(conn[0]);
        }
        if(!IsConnected(n, adjList))
            return -1;

        connections = connections.OrderBy(x => x[2]).ToArray();

        int totalCost = 0;
        foreach(var conn in connections) {
            if(disjointSet.UnionSet(conn[0],conn[1]))
                totalCost += conn[2];
        }
        return totalCost;
    }
    public bool IsConnected(int n, Dictionary<int, List<int>> adjList) {
        var visited = new HashSet<int>();
        DFS(1);
        
        return visited.Count == n;
        
        void DFS(int vertexU) {
            visited.Add(vertexU);
            foreach(var vertexV in adjList[vertexU]) {
                if(!visited.Contains(vertexV))
                    DFS(vertexV);
            }
        }
    }

    public class DisjointSet {
        public class Node {
            public int Data;
            public Node Parent;
            public int Rank;
            public Node(int data, int Rank) {
                this.Data = data; this.Parent = this;
            }
        }
        Dictionary<int, Node> Sets = new Dictionary<int, Node>();
        int rank = 0;
        public void MakeSet(int data) {
            if(!Sets.ContainsKey(data))
                Sets.Add(data, new Node(data, rank++));
        }
        public Node FindParent(int data) {
            return FindParent(Sets[data]);
        }
        public Node FindParent(Node node) {
            if(node.Data == node.Parent.Data)
                return node;
            node.Parent = FindParent(node.Parent);
            return node.Parent;
        }
        public bool UnionSet(int data1, int data2) {
            Node parent1 = FindParent(data1), parent2 = FindParent(data2);
            if(parent1 == parent2)
                return false;
            if(parent1.Rank < parent2.Rank) 
                Sets[data1].Parent = Sets[data2].Parent = parent2.Parent = parent1;
            else
                Sets[data1].Parent = Sets[data2].Parent = parent1.Parent = parent2;
            return true;
        }
    }
}