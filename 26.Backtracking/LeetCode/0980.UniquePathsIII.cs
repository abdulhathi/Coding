using System;
using System.Collections.Generic;

public class UniquePathsIII {
    public UniquePathsIII() {
        int[][] grid = {
            new int[] {0,0,0,0,0,0,2,0,0,0}, new int[] {0,0,0,0,0,0,0,0,1,0}
            // new int[] {1,-1,2},
            // new int[] {1,0,0,0},
            // new int[] {0,0,0,0},
            // new int[] {0,0,2,-1}
        };
        Console.WriteLine(UniquePathsIII_HC(grid));
    }
    public int UniquePathsIII_HC(int[][] grid) {
        var adjList = new Dictionary<int, HashSet<int>>();
        var visited = new HashSet<int>();
        int vCount = 0, rowLen = grid.Length, colLen = grid[0].Length;
        int pathCount = 0, source = 1, destination = 0;
        // Console.WriteLine(rowLen+" "+colLen);

        for(int i = 1; i <= (rowLen * colLen); i++)
            adjList.Add(i, new HashSet<int>());
        
        for(int r = 0; r < rowLen; r++) {
            for(int c = 0; c < colLen; c++) {
                if(grid[r][c] == 1 || grid[r][c] == 0 || grid[r][c] == 2) {
                    vCount++;
                    if(grid[r][c] == 2)
                        destination = vCount;
                    if(grid[r][c] == 1)
                        source = vCount;
                    if(c > 0 && grid[r][c-1] != -1)
                        adjList[vCount].Add(vCount-1);
                    if(r > 0 && grid[r-1][c] != -1)
                        adjList[vCount].Add(vCount-colLen);
                    if(c+1 < colLen && grid[r][c+1] != -1)
                        adjList[vCount].Add(vCount+1);
                    if(r+1 < rowLen && grid[r+1][c] != -1)
                        adjList[vCount].Add(vCount+colLen);
                }
            }
        }
        
        visited.Add(source);
        DFS(source);
        return pathCount;

        void DFS(int parentV) {
            if(visited.Count+1 == vCount && adjList[parentV].Contains(destination)) {
                pathCount++;
                // Console.WriteLine(string.Join(",",visited));
            }
            else {
                for(int vertex = 1; vertex <= vCount; vertex++) {
                    // Check the vertex is not the destination
                    if(vertex == destination)
                        continue;
                    // Check the vertex is visited already
                    if(visited.Contains(vertex))
                        continue;
                    
                    // Check the vertex has the edge with parent
                    if(!adjList[parentV].Contains(vertex))
                        continue;
                    
                    // Check the last vertex has the edge with destination
                    if(visited.Count+1 == vCount-1 && !adjList[vertex].Contains(destination))
                        continue;

                    visited.Add(vertex);
                    DFS(vertex);
                    visited.Remove(vertex);
                }
            }
        }
    }
}