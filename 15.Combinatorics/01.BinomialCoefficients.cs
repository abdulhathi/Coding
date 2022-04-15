using System;

public class BinomialCoefficients {
    int[][] tabulation = null;

    public BinomialCoefficients() {
        int n = Convert.ToInt32(Console.ReadLine());
        ComputeNCR(n);
        // Query NCR
        int quries = 5;
        while(quries-- > 0) {
            Console.WriteLine("Enter the N value : ");
            int r = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the R value : ");
            int c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(tabulation[r][c]);
        }   
    }

    public void ComputeNCR(int n) {
        tabulation = new int[n+1][];
        for(int r = 0; r <= n; r++) {
            tabulation[r] = new int[n+1];
            for(int c = 0; c <= r; c++) {
                if(c == 0 || r == c)
                    tabulation[r][c] = 1;
                else
                    tabulation[r][c] = tabulation[r-1][c] + tabulation[r-1][c-1];
            }
        }
    }
}