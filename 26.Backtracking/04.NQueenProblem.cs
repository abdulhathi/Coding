using System;
using System.Collections.Generic;

public class NQueenProblem {
    public NQueenProblem() {
        var allPossiblePos = PossibleNQueenPosition(5);
        foreach(var eachPos in allPossiblePos)
            Console.WriteLine(string.Join(",",eachPos));
    }
    public List<int[]> PossibleNQueenPosition(int n) {
        /* Constraints :
            1. Queens should not be in same row.
            2. Queens should not be in same column.
            3. Queens should not be in same diagnol position.
        */
        List<int[]> allPossiblePosition = new List<int[]>();
        int[] position = new int[n];
        int[,] tabulation = new int[n,n];
        
        for(int i = 0; i < n; i++)
            position[i] = -1;

        DFS(0);
        return allPossiblePosition;

        void DFS(int q) {
            if(q == n) {
                allPossiblePosition.Add(position.ToArray());
            } 
            else {
                for(int i = 0; i < n; i++) {
                    // Condition check for row attack
                    if(position[i] != -1)
                        continue;
                    // While Condition check for diagnol attack
                    bool diagnolExist = false;
                    int j = 1;
                    while(q-j >= 0) {
                        if((i-j >= 0 && tabulation[q-j,i-j] == 1) || (i+j < n && tabulation[q-j,i+j] == 1)) {
                            diagnolExist = true;
                            break;
                        }
                        j++;
                    }
                    if(diagnolExist)
                        continue;
                    position[i] = q;
                    tabulation[q,i] = 1;
                    DFS(q+1);
                    tabulation[q,i] = 0;
                    position[i] = -1;
                }
            }
        }
    }
}