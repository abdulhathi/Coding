// Using catalan number to find number possible BST in Dynamic programming based approach.
// f(n) = Summation(f(i-1)*f(n-i)); i = 1 to n
public class CatalanNumber {
    public CatalanNumber() {
        Console.WriteLine($"Top down approach {TopDownApproach(4)} ");
        Console.WriteLine($"Bottom up approach {BottomUpApproach(4)} ");
    }

    // Time complexity : O(n^2) Space : O(n)
    public int TopDownApproach(int N) {
        int[] memory = Enumerable.Range(0, N+1).Select(x => -1).ToArray();
        
        return Recursive(N);

        int Recursive(int n) {
            if(n == 0 || n == 1)
                return 1;

            if(memory[n] > -1)
                return memory[n];
            
            int bstCount = 0;
            for(int i = 1; i <= n; i++) {
                bstCount += Recursive(i-1)*Recursive(n-i);
            }
            memory[n] = bstCount;
            return memory[n];
        }
    }

    public int BottomUpApproach(int N) {
        int[] tabulation = new int[N+1];
        tabulation[0] = tabulation[1] = 1;

        for(int n = 2; n <= N; n++) {
            for(int i = 1; i <= n; i++) {
                tabulation[n] += tabulation[i-1] * tabulation[n-i];
            }
        }
        return tabulation[N];
    }
}