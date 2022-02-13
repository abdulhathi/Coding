using System;

public class CuttingARod {
    public CuttingARod() {
        int[] pieces = {1,2,3,4}, price = {2,5,7,8}; 
        int rodLength = 5;
        int max = GetMaxValueForCuttingRod(pieces,price,rodLength);
        Console.WriteLine(max);
    }
    public int GetMaxValueForCuttingRod(int[] pieces, int[] price, int rodLength) {
        int rowLen = pieces.Length+1, colLen = rodLength+1;
        int[,] tabulation = new int[rowLen,colLen];
        for(int r = 1; r < rowLen; r++) {
            for(int c = 1; c < colLen; c++) {
                if(pieces[r-1] > c)
                    tabulation[r,c] = tabulation[r-1,c];
                else 
                    tabulation[r,c] = Math.Max(tabulation[r-1,c], price[r-1] + tabulation[r, c-pieces[r-1]]);
            }
        }
        return tabulation[rowLen-1, colLen-1];
    }
}