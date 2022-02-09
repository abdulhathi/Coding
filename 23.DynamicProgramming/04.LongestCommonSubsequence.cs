using System;

public class LongestCommonSubsequence {
    public LongestCommonSubsequence() {
        string str1 = "bd", str2 = "abcd";
        Console.WriteLine(LongestCommonSubseq(str1,str2,0,0, new int?[str1.Length+1, str2.Length+1]));
        Console.WriteLine(LongestCommonSebSeq(str1,str2));
    }

    // Top down, Recursive, Memoization method
    public int LongestCommonSubseq(string str1, string str2, int i, int j, int?[,] memory) {
        if(i == str1.Length || j == str2.Length)
            return 0;
        if(str1[i] == str2[j]) {
            if(memory[i+1,j+1] == null)
                memory[i+1, j+1] = LongestCommonSubseq(str1, str2, i+1, j+1, memory);
            return 1 + memory[i+1, j+1].Value;
        }
        else {
            if(memory[i+1,j] == null)
                memory[i+1,j] = LongestCommonSubseq(str1, str2, i+1, j, memory);
            if(memory[i,j+1] == null)
                memory[i,j+1] = LongestCommonSubseq(str1, str2, i, j+1, memory);
            return Math.Max(memory[i+1,j].Value, memory[i,j+1].Value);
        }
    }

    // Bottom Up, Iterative, Tabulation method
    public int LongestCommonSebSeq(string str1, string str2) {
        int rowLength = str1.Length+1, colLength = str2.Length+1;
        int[,] tabulation = new int[rowLength,colLength];
        for(int r = 1; r < rowLength; r++)
            for(int c = 1; c < colLength; c++)
                if(str1[r-1] == str2[c-1])
                    tabulation[r,c] = 1 + tabulation[r-1,c-1];
                else
                    tabulation[r,c] = Math.Max(tabulation[r,c-1], tabulation[r-1,c]);
        return tabulation[rowLength-1,colLength-1];
    }
}