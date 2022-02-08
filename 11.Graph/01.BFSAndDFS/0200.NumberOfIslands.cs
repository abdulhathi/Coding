using System;

public class NumberOfIslands {
    public NumberOfIslands() {
        // char[][] grid = {
        //         new char[] {'1','1','0','1','0'},
        //         new char[] {'1','1','0','1','0'},
        //         new char[] {'1','1','0','0','0'},
        //         new char[] {'0','0','0','0','1'}
        //     };
        char[][] grid = {new char[] {'1','0','1','1','1'},new char[] {'1','0','1','0','1'},new char[] {'1','1','1','0','1'}};
        Console.WriteLine(NumIslands_UnionFind(grid));
        Console.WriteLine(NumIslands(grid));
    }
    // Method 1 : DFS
    public int NumIslands(char[][] grid) {
        int numOfIslands = 0;
        for(int r = 0; r < grid.Length; r++) {
            for(int c = 0; c < grid[r].Length; c++)
                if(grid[r][c] == '1')
                {
                    numOfIslands++;
                    DFS(r,c);
                }
        }
        return numOfIslands;

        void DFS(int row, int col) {
            if(row < 0 || row > grid.Length -1 || col < 0 || col > grid[row].Length-1 || grid[row][col] == '0'
            || grid[row][col] == '2')
                return;
            else {
                grid[row][col] = '2';
                DFS(row, col-1);
                DFS(row-1, col);
                DFS(row, col+1);
                DFS(row+1, col);
            }
        }
    }

    // Method 2 : UnionFind
    public class DisjointSet {
        public class Node {
            public int Val;
            public Node Parent;
            public int Rank;
            public Node(int val, int rank) { this.Val = val; this.Parent = this; this.Rank = rank; }
        }
        private Dictionary<int, Node> Sets = new Dictionary<int, Node>();
        private int rank = 0;
        public void MakeSet(int val) {
            if(!Sets.ContainsKey(val))
                Sets.Add(val, new Node(val, rank++));
        }
        public Node FindParent(int val) {
            return Sets.ContainsKey(val) ? FindParent(Sets[val]) : null;
        }
        private Node FindParent(Node child) {
            if(child.Parent == child)
                return child;
            child.Parent = FindParent(child.Parent);
            return child.Parent;
        }
        public bool UnionSet(int val1, int val2) {
            Node parent1 = FindParent(val1), parent2 = FindParent(val2);
            if(parent1 == null || parent2 == null ||  parent1 == parent2)
                return false;
            if(parent1.Rank < parent2.Rank)
                Sets[val1].Parent = Sets[val2].Parent = parent2.Parent = parent1;
            else
                Sets[val1].Parent = Sets[val2].Parent = parent1.Parent = parent2;
            return true;
        }
        public int CountUniqueSets() {
            var uniqueParentSet = new HashSet<int>();
            foreach(var key in Sets.Keys)
                uniqueParentSet.Add(FindParent(key).Val);
            return uniqueParentSet.Count;
        }
    }

    public int NumIslands_UnionFind(char[][] grid) {
        var disjointSet = new DisjointSet();
        // MakeSet in disjoint sets
        for(int r = 0; r < grid.Length; r++) {
            for(int c = 0; c < grid[r].Length; c++) {
                if(grid[r][c] == '1') disjointSet.MakeSet(r*grid[r].Length+c);
            }
        }
        for(int r = 0; r < grid.Length; r++) {
            for(int c = 0; c < grid[r].Length; c++) {
                if(grid[r][c] == '1') {
                    int cell = (r*grid[r].Length)+c;
                    if(c-1 >= 0 && grid[r][c-1] == '1') disjointSet.UnionSet(cell, ((r)*grid[r].Length)+c-1);
                    if(r-1 >= 0 && grid[r-1][c] == '1') disjointSet.UnionSet(cell, ((r-1)*grid[r].Length)+c);
                    if(c+1 < grid[r].Length && grid[r][c+1] == '1') disjointSet.UnionSet(cell, ((r)*grid[r].Length)+c+1);
                    if(r+1 < grid.Length && grid[r+1][c] == '1') disjointSet.UnionSet(cell, ((r+1)*grid[r].Length)+c);
                }
            }
        }
        return disjointSet.CountUniqueSets();
    }
}