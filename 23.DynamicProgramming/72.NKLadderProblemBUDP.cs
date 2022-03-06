using System;

/* 
    0 1 2 3 4 5 6 7
    1 1 
*/
public class NKLadderProblemBUDP {
    public NKLadderProblemBUDP() {
        Console.WriteLine(BottomUp_Tabulation(7, 3));
        Console.WriteLine(BottomUp_Tabulation_Optimized(7, 3));
    }
    // calculate the possible climb steps up to k iteration
    // Time O(n*k) Space O(n)
    public int BottomUp_Tabulation(int n, int k) {
        int[] tabulation = new int[n+1];
        tabulation[0] = 1;

        for(int i = 1; i <= n; i++) {
            for(int j = i - k; j < i; j++) {
                if(j >= 0)
                    tabulation[i] += tabulation[j];
            }
        }
        return tabulation[n];
    }

    // Time O(n) and Space O(n)
    public int BottomUp_Tabulation_Optimized(int n, int k) {
        int[] tabulation = new int[n+1];
        tabulation[0] = tabulation[1] = 1;

        for(int i = 2; i <= n; i++) {
            tabulation[i] += 2*(tabulation[i-1]) - ((i - k - 1) >= 0 ? tabulation[(i - k - 1)] : 0);
        }
        return tabulation[n];
    }
}