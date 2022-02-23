using System;

public class ScoreAfterFlippingMatrix {
    public ScoreAfterFlippingMatrix() {
        int[][] grid = { new int[]{0,0,1,1}, new int[]{1,0,1,0}, new int[]{1,1,0,0} };
        int score = MatrixScore(grid);
        Console.WriteLine(score);
    }
    public int MatrixScore(int[][] grid) {
        int rowLen = grid.Length, colLen = grid[0].Length;
        // Row wise toggling
        for(int r = 0; r < rowLen; r++) {
            int[] newRow = new int[colLen];
            int toggleVal = 0, actualVal = 0;
             for(int c = 0; c < colLen; c++) {
                newRow[c] = grid[r][c] == 0 ? 1 : 0;
                toggleVal += (newRow[c] << colLen-1-c);
                actualVal += (grid[r][c] << colLen-1-c);
            }
            if(toggleVal > actualVal)
                grid[r] = newRow;
        }
        
        // Column wise toggling
        for(int c = 0; c < colLen; c++) {
            int setBitCount = 0;
            for(int r = 0; r < rowLen; r++)
                setBitCount += grid[r][c]; 
            if(setBitCount <= rowLen/2) {
                for(int r = 0; r < rowLen; r++)
                    grid[r][c] = grid[r][c] == 0 ? 1 : 0; 
            }
        }
        
        // count bit value
        int score = 0;
        for(int r = 0; r < rowLen; r++) {
            for(int c = 0; c < colLen; c++) {
                score += grid[r][c] << colLen-1-c;
            }
        }
        return score;
    }
}