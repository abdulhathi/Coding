using System;
using System.Collections.Generic;

public class BellmenFordSingleSourceShortestPath {
    public BellmenFordSingleSourceShortestPath() {
        Dictionary<int, Dictionary<int, int>> adjList = new Dictionary<int, Dictionary<int, int>>();
        for(int i = 0; i <= 4; i++)
            adjList.Add(i, new Dictionary<int, int>());
        adjList[3].Add(4,2); adjList[4].Add(3,1); adjList[2].Add(4,4); 
        adjList[0].Add(2,5); adjList[1].Add(2,-3); 
        adjList[0].Add(3,8); adjList[0].Add(1,4);

        BellmenFordShortestPath(0, adjList);
    }

    public void BellmenFordShortestPath(int source, Dictionary<int, Dictionary<int, int>> adjList) {
        Dictionary<int, (int Distance, int? Parent)> parentAndDistanceMap = new Dictionary<int, (int Distance, int? Parent)>();
        int i = 0; 
        bool isRelaxed = true;
        
        foreach(var vertex in adjList.Keys)
            parentAndDistanceMap.Add(vertex, (int.MaxValue, null));
        parentAndDistanceMap[source] = (0, parentAndDistanceMap[source].Parent);

        while(i++ < adjList.Count && isRelaxed) {
            isRelaxed = false;
            foreach(var vertexU in adjList) {
                foreach(var vertexV in vertexU.Value) {
                    if(parentAndDistanceMap[vertexU.Key].Distance + vertexV.Value < parentAndDistanceMap[vertexV.Key].Distance) {
                        parentAndDistanceMap[vertexV.Key] = (parentAndDistanceMap[vertexU.Key].Distance + vertexV.Value, vertexU.Key);
                        isRelaxed = true;
                    }
                }
            }
        }
        Console.WriteLine();
        foreach(var parentAndDistance in parentAndDistanceMap) {
            string parent = parentAndDistance.Value.Parent == null ? "null" : parentAndDistance.Value.Parent.Value.ToString();
            Console.WriteLine($"{parentAndDistance.Key}, Distance: {parentAndDistance.Value.Distance}, Parent: {parent}");
        }
    }
}