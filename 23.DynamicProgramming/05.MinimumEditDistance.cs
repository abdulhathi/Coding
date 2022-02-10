using System;

public class MinimumEditDistance {
    public MinimumEditDistance() {
        Console.Write(MinEditDistance("azcea", "abcdef"));
    }
    // Bottom up approach and iterative procedure and tabulation method.
    public int MinEditDistance(string str1, string str2) {
        int rowLength = str1.Length+1, colLength = str2.Length+1;
        int[,] tabulation = new int[rowLength,colLength];
        // Update the initial values in the row 0
        for(int i = 0; i < colLength; i++)
            tabulation[0,i] = i;
        // Update the initial values in the column 0
        for(int i = 0; i < rowLength; i++)
            tabulation[i,0] = i;

        // Find the min edit value
        for(int r = 1; r < rowLength; r++) {
            for(int c = 1; c < colLength; c++) {
                if(str1[r-1] == str2[c-1])
                    tabulation[r,c] = tabulation[r-1,c-1];
                else
                    tabulation[r,c] = 1 + Math.Min(Math.Min(tabulation[r,c-1], tabulation[r-1,c-1]), tabulation[r-1,c]);
            }
        }
        Console.WriteLine();
        int row = rowLength-1, col = colLength - 1;
        while(row > 0 && col > 0) {
            if(str1[row-1] == str2[col-1]) {
                Console.WriteLine($"{str1[row-1]} are matching {str2[col-1]}");
                row--; col--;
            }
            else {
                int leftVal = tabulation[row,col-1], diagVal = tabulation[row-1,col-1], topVal = tabulation[row-1,col];
                if(diagVal < tabulation[row,col]) {
                    Console.WriteLine($"{str2[col-1]} is updated to {str1[row-1]}");
                    row--; col--;
                }
                else if(leftVal < tabulation[row,col]) {
                    Console.WriteLine($"{str2[col-1]} is deleted");
                    col--;
                }
                else {
                    Console.WriteLine($"{str2[col-1]} is inserted");
                    row--;
                }
            }
        }

        return tabulation[rowLength-1, colLength-1];
    }
}