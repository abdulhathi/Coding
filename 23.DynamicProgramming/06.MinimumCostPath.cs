using System;

public class MinimumCostPath {
    public MinimumCostPath() {
        int[,] matrix = { {1,3,5,8},{4,2,1,7},{4,3,2,3} };
        Console.WriteLine($"Min cost {FindMinCostPathInMatrix(matrix)}");
    }
    public int FindMinCostPathInMatrix(int[,] matrix) {
        int rowLength = matrix.GetLength(0), colLength = matrix.GetLength(1);
        int[,] tabulation = new int[rowLength, colLength];
        // Insert the intial value of (0,0)
        tabulation[0,0] = matrix[0,0];
        // calculate the first row sum
        for(int c = 1; c < colLength; c++)
            tabulation[0,c] = tabulation[0,c-1] + matrix[0,c];
        // calculate the first col sum
        for(int r = 1; r < rowLength; r++)
            tabulation[r,0] = tabulation[r-1,0] + matrix[r,0];

        for(int r = 1; r < rowLength; r++)
            for(int c = 1; c < colLength; c++)
                tabulation[r,c] = Math.Min(tabulation[r,c-1], tabulation[r-1,c]) + matrix[r,c];

        return tabulation[rowLength-1, colLength-1];
    }
}