/*
    The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.
    Given an integer n, return all distinct solutions to the n-queens puzzle. You may return the answer in any order.

    Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space, respectively.

    Example 1:
        Input: n = 4
        Output: [[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
        Explanation: There exist two distinct solutions to the 4-queens puzzle as shown above

    Example 2:
        Input: n = 1
        Output: [["Q"]]
    
    Constraints:
        1 <= n <= 9 

    https://leetcode.com/problems/n-queens/
*/
using System;
using System.Collections.Generic;

public class NQueens {
    public NQueens() {
        var allPossiblePos = SolveNQueens(5);
        Console.WriteLine();
        foreach(var eachPos in allPossiblePos)
            Console.WriteLine(string.Join(",",eachPos));
    }
    public IList<IList<string>> SolveNQueens(int n) {
        var allPossiblePos = new List<IList<string>>();
        var tabulation = new int[n,n];
        var currentPos = new int[n];
        var qChars = new char[n];
        int j = 0; bool diagQueenExist = false;
        for(int i = 0; i < n; i++) {
            currentPos[i] = -1;
            qChars[i] = '.';
        }
        
        DFS(0);
        return allPossiblePos;
        
        void DFS(int q) {
            if(q == n) {
                var listOfPos = new List<string>();
                foreach(var pos in currentPos) {
                    qChars[pos] = 'Q';
                    listOfPos.Add(string.Join("",qChars));
                    qChars[pos] = '.';
                }
                allPossiblePos.Add(listOfPos);
            }
            else {
                for(int i = 0; i < n; i++) {
                    if(currentPos[i] != -1)
                        continue;
                    j = 1; diagQueenExist = false;
                    while(q-j >= 0) {
                        if((i-j >= 0 && tabulation[q-j,i-j] == 1) || 
                                       (i+j < n && tabulation[q-j,i+j] == 1)) {
                            diagQueenExist = true;
                            break;
                        }
                        j++;
                    }
                    if(diagQueenExist)
                        continue;
                    currentPos[i] = q;
                    tabulation[q,i] = 1;
                    DFS(q+1);
                    tabulation[q,i] = 0;
                    currentPos[i] = -1;
                }
            }
        }
    }
}