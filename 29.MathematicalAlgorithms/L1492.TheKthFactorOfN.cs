using System;

public class TheKthFactorOfN {
    public TheKthFactorOfN() {
        // 1,2,3,4,6,12
        Console.WriteLine(KthFactor_Recursive(12,1));
    }
    // O(n+k) time and O(√n) space
    public int KthFactor(int n, int k) {
        var sortedSet = new SortedSet<int>();
        Factorial(n);
        while(k - 1 > 0) {
            k -= 1;
            sortedSet.Remove(sortedSet.Min);
        }
        return sortedSet.Count > 0 ? sortedSet.Min : -1;
            
        void Factorial(int i) {
            if(i > 0) {
                if(n % i == 0)
                    sortedSet.Add(i);
                Factorial(i-1);
            }
        }
    }
    // Time: O(n), Space: O(1)
    public int KthFactor_Recursive(int n, int k) {
        return KthFactor_Recursive(n);

        int KthFactor_Recursive(int i) {
            if(i <= 0)
                return -1;
            int kthVal = KthFactor_Recursive(i-1);
            if(n % i == 0 && kthVal == -1)
                k--;
            if(k == 0 && kthVal == -1)
                return i;
            return kthVal;
        }
    }
     // Time: O(n), Space: O(1)
    public int KthFactor_Iterative(int n, int k) {
        for(int i = 1; i <= n; i++) {
            if(n % i == 0)
                k--;
            if(k == 0)
                return i;
        }
        return -1;
    }
}