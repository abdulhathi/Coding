/*
    The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.
    Given an integer n, return the number of distinct solutions to the n-queens puzzle.

    Example 1:
        Input: n = 4
        Output: 2
        Explanation: There are two distinct solutions to the 4-queens puzzle as shown.

    Example 2:
        Input: n = 1
        Output: 1

    Constraints:
        1 <= n <= 9

    https://leetcode.com/problems/n-queens-ii/
*/
public class NQueensII {
    public NQueensII() {
        Console.WriteLine(TotalNQueens(5));
    }
    public int TotalNQueens(int n) {
        int[,] table = new int[n,n];
        int[] pos = new int[n];
        int count = 0, j = 1; bool diagQueenExist = false;
        for(int i = 0; i < n; i++) 
            pos[i] = -1;
        
        DFS(0);
        return count;
        
        void DFS(int q) {
            if(q == n)
                count++;
            else {
                for(int i = 0; i < n; i++) {
                    if(pos[i] != -1)
                        continue;
                    j = 1; diagQueenExist = false;
                    while(q-j >= 0) {
                        if((i-j >= 0 && table[q-j,i-j] == 1) || (i+j < n && table[q-j,i+j] == 1)) {
                            diagQueenExist = true;
                            break;
                        }
                        j++;
                    }
                    if(diagQueenExist)
                        continue;
                    
                    pos[i] = q;
                    table[q,i] = 1;
                    DFS(q+1);
                    table[q,i] = 0;
                    pos[i] = -1;
                }
            }
        }
    }
}