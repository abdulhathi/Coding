using System;

public class PrimeSieve {
    const int N = 10000000;
    bool[] sieve = null;

    public PrimeSieve() {
        sieve = Enumerable.Range(0, N+1).Select(x => true).ToArray();
        CreatePrimeSieve();
        PrintPrimeUptoNum(10000000);
    }
    public void CreatePrimeSieve() {
        
        // Mark 0 & 1 both are not prime
        sieve[0] = sieve[1] = false;

        // Mark from the number 2 to all the ith number multiples are not prime.
        for(ulong i = 2; i < N; i++) {
            if(sieve[i]) {
                for(ulong j = i*i; j < N; j += i) 
                    sieve[j] = false;
            }
        }
    }
    public void PrintPrimeUptoNum(int num) {
        for(int i = 0; i <= num; i++)
            if(sieve[i])
                Console.Write(i+",");
    }
}