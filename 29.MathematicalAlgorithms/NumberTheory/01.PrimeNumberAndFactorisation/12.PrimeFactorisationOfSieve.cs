public class PrimeFactorisationOfSieve {
    public PrimeFactorisationOfSieve() {
        // Console.WriteLine("Prime Factorisation using Sieve Method");
        FindPrimeFactsUsingSieve(16);
    }

    public void FindPrimeFactsUsingSieve(int num) {
        int[] primeFactSieve = new int[num+1];
        
        for(int i = 2; i <= num; i++) {
            if(primeFactSieve[i] == 0) {
                for(int j = i; j <= num; j = j+i) {
                    if(primeFactSieve[j] == 0)
                        primeFactSieve[j] = i;
                }
            }
        }
        Console.WriteLine(string.Join(",", primeFactSieve));

        while(primeFactSieve[num] > 0) {
            Console.WriteLine(primeFactSieve[num]);
            num = num / primeFactSieve[num];
        }
    }
}