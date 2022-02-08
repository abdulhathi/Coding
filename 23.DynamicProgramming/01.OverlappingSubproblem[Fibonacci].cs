/*Dynamic Programming is an algorithmic paradigm that solves a given complex problem by breaking it into subproblems and stores the results of subproblems to avoid computing the same results again. Following are the two main properties of a problem that suggests that the given problem can be solved using Dynamic programming.

In this post, we will discuss the first property (Overlapping Subproblems) in detail. The second property of Dynamic programming is discussed in the next post i.e. Set 2.
1) Overlapping Subproblems 
2) Optimal Substructure

1) Overlapping Subproblems: 
Like Divide and Conquer, Dynamic Programming combines solutions to sub-problems. Dynamic Programming is mainly used when solutions of the same subproblems are needed again and again. In dynamic programming, computed solutions to subproblems are stored in a table so that these don’t have to be recomputed. So Dynamic Programming is not useful when there are no common (overlapping) subproblems because there is no point storing the solutions if they are not needed again. For example, Binary Search doesn’t have common subproblems. If we take an example of following recursive program for Fibonacci Numbers, there are many subproblems that are solved again and again.*/
using System;

public class OverlappingSubproblem {
    public OverlappingSubproblem() {
        /*Index : 0 1 2 3 4 5 6 7  8
            Fib : 0 1 1 2 3 5 8 13 21
        */
        Console.WriteLine($"Top Down approach with memoization fib(8) is : {Fibonacci_TopDown(8, new Dictionary<int,int>())}");

        Console.WriteLine($"Bottom up approach with memoization fib(8) is : {Fibonacci_BottomUp(8)}");
    }
    // Recursive find the Fib(5) from top 5 to bottom 0
    public int Fibonacci_TopDown(int n) {
        if(n <= 1) return n;
        return Fibonacci_TopDown(n-1) + Fibonacci_TopDown(n-2);
    }
    // Memoization 
    public int Fibonacci_TopDown(int n, Dictionary<int,int> memory) {
        if(n <= 1) return n;
        if(!memory.ContainsKey(n-2))
            memory.Add(n-2, Fibonacci_TopDown(n-2, memory));
        if(!memory.ContainsKey(n-1))
            memory.Add(n-1, Fibonacci_TopDown(n-1, memory));
        return memory[n-1] + memory[n-2];
    }
    // Iterative Bottom up the Fib(5) from bottom 1 to top 5
    public int Fibonacci_BottomUp(int n) {
        int[] memory = new int[n];
        memory[0] = 0;
        memory[1] = 1;
        for(int i = 2; i < n; i++) {
            memory[i] = memory[i-2] + memory[i-1];
        }
        return memory[n-2] + memory[n-1];
    }
}