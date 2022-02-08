using System;
using System.Collections.Generic;

public class ReconstructItinerary {
    public ReconstructItinerary() {
        List<IList<string>> tickets = new List<IList<string>>();
        string input = "'EZE','TIA'],['EZE','HBA'],['AXA','TIA'],['JFK','AXA'],['ANU','JFK'],['ADL','ANU'],['TIA','AUA'],['ANU','AUA'],['ADL','EZE'],['ADL','EZE'],['EZE','ADL'],['AXA','EZE'],['AUA','AXA'],['JFK','AXA'],['AXA','AUA'],['AUA','ADL'],['ANU','EZE'],['TIA','ADL'],['EZE','ANU'],['AUA','ANU'";
        foreach(var edge in input.Split("],["))
        {
            string[] vertices = edge.Replace("'","").Split(",");
            tickets.Add(new List<string> {vertices[0],vertices[1]});
        }

        Console.Write(string.Join(",", FindItinerary(tickets)));
    }
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        var adjList = new Dictionary<string, List<string>>();
        var stack = new Stack<string>();
        var output = new List<string>();
        var keys = new HashSet<string>();
        
        // Build adjList, inDegree & outDegree
        string u = "", v ="";
        foreach(var ticket in tickets) {
            u = ticket[0]; v = ticket[1];
            if(!adjList.ContainsKey(u))
                adjList.Add(u, new List<string>());
            if(!adjList.ContainsKey(v))
                adjList.Add(v, new List<string>());
            adjList[u].Add(v);
            keys.Add(u); 
            keys.Add(v);
        }
        
        foreach(var key in keys) 
            adjList[key] = adjList[key].OrderByDescending(x => x).ToList();

        DFS("JFK");
        
        while(stack.Count > 0)
            output.Add(stack.Pop());
        return output;
        
        void DFS(string vertexU) {
            while(adjList[vertexU].Count > 0) {
                var vertexV = adjList[vertexU][adjList[vertexU].Count - 1];
                adjList[vertexU].RemoveAt(adjList[vertexU].Count - 1);
                DFS(vertexV);
            }
            if(adjList[vertexU].Count == 0)
                stack.Push(vertexU);
        }
    }
}