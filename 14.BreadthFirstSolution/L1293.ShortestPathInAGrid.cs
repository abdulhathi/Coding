public class ShortestPathInAGrid {
    public ShortestPathInAGrid() {
        int[][] grid = { new int[] {0,1,0,0,0,1,0,0},
                         new int[] {0,1,0,1,0,1,0,1},
                         new int[] {0,0,0,1,0,0,1,0} };
        int path = ShortestPath(grid, 1);
        Console.WriteLine(path);
    }
    public class StepCount {
        public int Steps;
        public int Obstacle;
        public StepCount(int steps, int obstacle) {
            this.Steps = steps; this.Obstacle = obstacle;
        }
    }
    public class Cell {
        public int Row; 
        public int Col;
        public Cell(int row, int col) { this.Row = row; this.Col = col; }
    }
    public int ShortestPath(int[][] grid, int k) {
        StepCount[][] pathGrid = Enumerable.Range(0, grid.Length).Select(x => 
        Enumerable.Range(0, grid[0].Length).Select(y => new StepCount(-1,-1)).ToArray()).ToArray();
        int m = grid.Length, n = grid[0].Length;
        int[,] directions = { {0,-1}, {-1,0},{0,1},{1,0} };
        
        var queue = new Queue<Cell>();
        queue.Enqueue(new Cell(0,0));
        pathGrid[0][0] = new StepCount(0, k);
        while(queue.Count > 0) {
            var cell = queue.Dequeue();
            
            for(int i = 0; i < directions.GetLength(0); i++) {
                Cell temp = new Cell(cell.Row + directions[i,0], cell.Col + directions[i,1]);
                if(temp.Row < 0 || temp.Col < 0 || temp.Row >= m || temp.Col >= n)
                    continue;
                if(pathGrid[temp.Row][temp.Col].Obstacle < pathGrid[cell.Row][cell.Col].Obstacle) {
                    int obstcl = pathGrid[cell.Row][cell.Col].Obstacle;
                    if(grid[temp.Row][temp.Col] == 1)
                        obstcl = pathGrid[cell.Row][cell.Col].Obstacle - 1;
                    if(obstcl < 0)
                        continue;
                    if(temp.Row == m-1 && temp.Col == n-1) {
                        if(pathGrid[temp.Row][temp.Col].Steps != -1 &&
                        pathGrid[temp.Row][temp.Col].Steps < pathGrid[cell.Row][cell.Col].Steps+1)
                            continue;
                    }
                    pathGrid[temp.Row][temp.Col] = new StepCount(pathGrid[cell.Row][cell.Col].Steps+1, obstcl);
                    queue.Enqueue(temp);
                }
            }
        }
        return pathGrid[pathGrid.Length-1][pathGrid[0].Length-1].Steps;
    }
}