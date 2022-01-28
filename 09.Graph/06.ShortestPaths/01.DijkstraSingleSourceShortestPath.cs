using System;
using System.Collections.Generic;

public class DijkstraSingleSourceShortestPath
{
    public DijkstraSingleSourceShortestPath() {
        Dictionary<char, Dictionary<char, int>> adjList = new Dictionary<char, Dictionary<char, int>>();
        adjList.Add('A', new Dictionary<char, int>() { {'B',5}, {'D',9}, {'E',2} });
        adjList.Add('B', new Dictionary<char, int>() { {'C',2} });
        adjList.Add('C', new Dictionary<char, int>() { {'D',3} });
        adjList.Add('E', new Dictionary<char, int>() { {'F',3} });
        adjList.Add('F', new Dictionary<char, int>() { {'D',2} });
        adjList.Add('D', new Dictionary<char, int>() );

        DijkstrasShortestPath(adjList);
    }
    public void DijkstrasShortestPath(Dictionary<char, Dictionary<char, int>> adjList) {
        SortedSet<(int Cost, char Vertex)> heapSet = new SortedSet<(int Cost, char Vertex)>();
        Dictionary<char, int> weightMap = new Dictionary<char, int>();
        Dictionary<char, (char? Parent, int Cost)> parentAndWeightMap = new Dictionary<char, (char? Parent, int Cost)>();

        foreach(var vertex in adjList.Keys) {
            weightMap.Add(vertex, int.MaxValue);
            parentAndWeightMap.Add(vertex, (null, 0));
        } 
        char source = 'A';
        heapSet.Add((0, source));
        weightMap[source] = 0;

        while(heapSet.Count > 0) {
            var min = heapSet.Min;
            heapSet.Remove(min);
            weightMap.Remove(min.Vertex);
            
            foreach(var vertexV in adjList[min.Vertex]) {
                if(weightMap.ContainsKey(vertexV.Key) && weightMap[vertexV.Key] > vertexV.Value + min.Cost) {
                    if(heapSet.Contains((weightMap[vertexV.Key], vertexV.Key)))
                        heapSet.Remove((weightMap[vertexV.Key], vertexV.Key));
                    weightMap[vertexV.Key] = vertexV.Value + min.Cost;
                    heapSet.Add((vertexV.Value + min.Cost, vertexV.Key));
                    
                    parentAndWeightMap[vertexV.Key] = (min.Vertex, weightMap[vertexV.Key]);
                }
            }
        }
        Console.WriteLine();
        foreach(var parentAndWeight in parentAndWeightMap) {
            string parent = parentAndWeight.Value.Parent == null ? "null" : parentAndWeight.Value.Parent.Value.ToString();
            Console.WriteLine($"{parentAndWeight.Key}, Cost: {parentAndWeight.Value.Cost}, Parent: {parent}");
        }
    }
}