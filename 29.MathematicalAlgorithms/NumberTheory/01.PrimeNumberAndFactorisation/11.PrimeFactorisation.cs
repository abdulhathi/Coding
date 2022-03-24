public class PrimeFactorisation {
    public PrimeFactorisation() {
        FindPrimeFactors(99);
        FindPrimeFactors_Optimized(99);
    }
    // Brute force method
    // Time : O(n)
    public void FindPrimeFactors(int num) {
        for(int i = 2; i <= num; i++) {
            int primeCount = 0;
            while(num % i == 0) {
                primeCount++;
                num = num / i;
            }
            if(primeCount > 0)
                Console.WriteLine($"{i}^{primeCount}");
        }
    }
    // 0  1  2  3  4  5  6  7  8  9  10  11 12  13  14  15  16  17  18  19  20
    // Square Root method. 
    // Time  : O(Sqrt(N))
    public void FindPrimeFactors_Optimized(int num) {
        for(int i = 2; i*i <= num; i++) {
            int primeCount = 0;
            while(num % i == 0) {
                primeCount++;
                num = num / i;
            }
            if(primeCount > 0)
                Console.WriteLine($"{i}^{primeCount}");
        }    
        Console.WriteLine($"{num}^1");
    }
}