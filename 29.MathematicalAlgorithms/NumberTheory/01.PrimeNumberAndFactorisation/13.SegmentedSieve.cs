/*
    https://www.spoj.com/problems/PRIME1/
    Peter wants to generate some prime numbers for his cryptosystem. Help him! Your task is to generate all prime numbers between two given numbers!
    numbers m and n (1 <= m <= n <= 1000000000, n-m<=100000)
*/
public class SegmentedSieve {
    public SegmentedSieve() {
        int m = 999900000, n = 1000000000;
        GeneratePrimeNums(m, n);
    }

    public void GeneratePrimeNums(int m, int n) {
        DateTime start = DateTime.Now;
        // Step 1 : Find the squar root of n
        int primeLen = Convert.ToInt32(Math.Sqrt(n));

        // Step 2 : Create prime sieve up to square root of n
        bool[] primeSieve = Enumerable.Range(0, primeLen+1).Select(x => true).ToArray();
        HashSet<int> primes = new HashSet<int>();
        primeSieve[0] = primeSieve[1] = false;
        for(int i = 2; i <= primeLen; i++) {
            if(primeSieve[i]) {
                primes.Add(i);
                for(int j = i*i; j <= primeLen; j = j + i) 
                    primeSieve[j] = false;
            }
        }
        // Console.WriteLine(string.Join(",", primes));

        // Step 3: Create prime sieve up to m to n means 0(m-m) to n-m
        bool[] segmentedSieve = Enumerable.Range(0, n-m+1).Select(x => true).ToArray();
        // Loop all prime numbers and find its multiple starting from m
        foreach(var prime in primes) {
            // Get the first number
            int first = m < prime ? prime : (m/prime)*prime;
            // if the first number is still in the segmented sieve
            if(first >= m && first <= n)
                first = 2*prime; 
            
            // Iterate the from first to N if the iterate value j < m then skip those.
            for(int j = first; j <= n; j = j + prime) {
                if(j < m)
                    continue;
                segmentedSieve[j-m] = false;
            }
        }

        DateTime end = DateTime.Now;
        TimeSpan ts = end - start;
        Console.WriteLine(ts.Milliseconds);

        for(int i = 0; i <= n-m; i++)
            if(segmentedSieve[i])
                Console.Write(i+m+",");
        
        
    }
}