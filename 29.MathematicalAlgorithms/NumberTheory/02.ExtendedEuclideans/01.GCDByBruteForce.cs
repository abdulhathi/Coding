public class GCDByBruteForce {
    public GCDByBruteForce() {
        Console.WriteLine(GreatestCommonDivisorOfTwoNums(8,20));
    }
    // Bruteforce Method
    // Time O(min(m,n))
    public int GreatestCommonDivisorOfTwoNums(int m, int n) {
        int min = Math.Min(m,n);
        int gcd = 1;
        for(int i = 2; i <= min; i++) {
            if(m % i == 0 && n % i == 0) 
                gcd = Math.Max(gcd, i);
        }
        return gcd;
    }
}