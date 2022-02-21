using System;
using System.Collections.Generic;

public class GraphMColoring {
    public GraphMColoring() {
        int[][] edges = { new int[] {0,1}, new int[] {1,2}, new int[] {2,3}, new int[] {3,0}  };
        AllPossibleColoring(4, edges, 3);
    }
    public void AllPossibleColoring(int vertices, int[][] edges, int numOfColor) {
        var adjList = new Dictionary<int, List<int>>();
        var verticesColor = new Dictionary<int, int>();
        var colorCombination = new List<int>();

        foreach(var edge in edges) {
            if(!adjList.ContainsKey(edge[0])) {
                adjList.Add(edge[0], new List<int>());
                verticesColor.Add(edge[0],0);
            }
            if(!adjList.ContainsKey(edge[1])) {
                adjList.Add(edge[1],new List<int>());
                verticesColor.Add(edge[1],0);
            }
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        DFS(0);

        void DFS(int vertex) {
            if(vertex == vertices)
                Console.WriteLine(string.Join(",", colorCombination));
            else {
                for(int color = 1; color < numOfColor+1; color++) {
                    bool colorExistInAdj = false;
                    foreach(var adjV in adjList[vertex]) {
                        if(verticesColor[adjV] == color) {
                            colorExistInAdj = true;
                            break;
                        }
                    }
                    if(colorExistInAdj)
                        continue;
                    
                    colorCombination.Add(color);
                    verticesColor[vertex] = color;
                    DFS(vertex+1);
                    verticesColor[vertex] = 0;
                    colorCombination.RemoveAt(colorCombination.Count - 1);
                }
            }
        }
    }
}