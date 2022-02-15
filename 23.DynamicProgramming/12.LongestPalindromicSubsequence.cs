using System;

public class LongestPalindromicSubsequence {

    public LongestPalindromicSubsequence() {
        int lpsLength = LPS("agbdba".ToCharArray());
        // Console.WriteLine(lpsLength);
    }
    /*         |0  |1  |2  |3  |4  |5  |
            ----------------------------
            0  |0,0|0,1|0,2|0,3|0,4|0,5|
            1  |   |1,1|1,2|1,3|1,4|1,5|
            2  |   |   |2,2|2,3|2,4|2,5|
            3  |   |   |   |3,3|3,4|3,5|
            4  |   |   |   |   |4,4|4,5|
            5  |   |   |   |   |   |5,5|

    */
    public int LPS(char[] chars) {
        int r = 0, c = 0, i = 0, length = chars.Length;
        int[,] tabulation = new int[length,length];
        while(i < length) {
            r = 0; c = i;
            Console.WriteLine();
            while(r < length && c < length) {
                
                if(chars[r] == chars[c])
                    tabulation[r,c] = c-r > 0 ? (2 + tabulation[r+1,c-1]) : 1;
                else
                    tabulation[r,c] = Math.Max(tabulation[r,c-1], tabulation[r+1,c]);
                Console.Write($"{tabulation[r,c]} ");
                r++; c++;
            }
            i++;
        }
        return tabulation[0, length-1];
    }
}