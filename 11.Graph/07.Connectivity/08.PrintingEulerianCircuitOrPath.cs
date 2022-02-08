//https://www.youtube.com/watch?v=8MpoO2zA2l4
using System;
using System.Collections.Generic;

public class PrintingEulerianCircuitOrPath {
    public PrintingEulerianCircuitOrPath() {
        // List<IList<string>> adj = new List<IList<string>> { 
        //     new List<string> {"MUC","LHR"},
        //     new List<string> {"JFK","MUC"},
        //     new List<string> {"SFO","SJC"},
        //     new List<string> {"LHR","SFO"}
        // };
        List<IList<string>> adj = new List<IList<string>> { 
            new List<string> {"JFK","SFO"},
            new List<string> {"JFK","ATL"},
            new List<string> {"SFO","ATL"},
            new List<string> {"ATL","JFK"},
            new List<string> {"ATL","SFO"}
        };
       var result = PrintEulerianCircuit(adj);
       Console.Write(string.Join(",", result));
    }
    public IList<string> PrintEulerianCircuit(IList<IList<string>> adj) {
        var inAndOutDegree = new Dictionary<string, (int InDegree, int OutDegree, HashSet<string> adj)>();
        var stack = new Stack<string>();
        var result = new List<string>();

        foreach(var edge in adj) {
            if(!inAndOutDegree.ContainsKey(edge[0]))
                inAndOutDegree.Add(edge[0], (0,0, new HashSet<string>()));
            if(!inAndOutDegree.ContainsKey(edge[1]))
                inAndOutDegree.Add(edge[1], (0,0, new HashSet<string>()));
            
            var vertex = inAndOutDegree[edge[0]];
            vertex.OutDegree++;
            vertex.adj.Add(edge[1]);
            inAndOutDegree[edge[0]] = vertex;

            vertex = inAndOutDegree[edge[1]];
            vertex.InDegree++;
            inAndOutDegree[edge[1]] = vertex;
        }
        // Find start vertex
        foreach(var vertexDegree in inAndOutDegree) {
            if(vertexDegree.Value.OutDegree - vertexDegree.Value.InDegree == 1) {
                DFS(vertexDegree.Key);
                break;
            }
        }
        while(stack.Count > 0) 
            result.Add(stack.Pop());
        return result;
        /*         (2) 
                   ^ |
                   | V
            (0)--->(1)--->(3)--->(4) 
            [0,1,2,1,3,4]
        */
        // DFS
        void DFS(string vertexU) {
            foreach(var vertexV in inAndOutDegree[vertexU].adj) {
                var vertex = inAndOutDegree[vertexU];
                if(vertex.adj.Count > 0) {
                    vertex.OutDegree--;
                    vertex.adj.Remove(vertexV);
                    inAndOutDegree[vertexU] = vertex;
                    DFS(vertexV);
                }
            }
            if(inAndOutDegree[vertexU].adj.Count == 0)
                stack.Push(vertexU);
        }
    }

}