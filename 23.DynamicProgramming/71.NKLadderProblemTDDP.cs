using System;

public class NKLadderProblemTDDP {
    public NKLadderProblemTDDP() {
        // Top down dynamic programming approach testing
        Console.WriteLine(TopDownDP(6, 3));
    }
    public int TopDownDP(int n, int k) {
        int[] memory = new int[n+1];
        return Recursive_Memoization(n);
        
        int Recursive_Memoization(int p) {
            // base case
            if(p == 0 || p == 1)
                return 1;

            // Retrive from memoization
            if(memory[p] != 0)
                return memory[p];

            // If memory dont have the value compute and assing the value to memory
            for(int i = p-k; i < p; i++)
                if(i >= 0) 
                    memory[p] += Recursive_Memoization(i);
            return memory[p];
        }
    }
}