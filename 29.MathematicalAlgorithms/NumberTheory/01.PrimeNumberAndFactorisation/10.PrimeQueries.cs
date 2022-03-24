using System;

public class PrimeQueries {

    public PrimeQueries() {
        // 2, 3, 5, 7, 11, 13, 17, 19
        Console.WriteLine(CountPrimeInRange(1,20));
    }

    public int CountPrimeInRange(int start, int end) {
        bool[] primeSieve = Enumerable.Range(0, end+1).Select(x => true).ToArray();
        int[] primeCount = new int[end+1];

        //Composite numbers 0 and 1 are not prime numbers.
        primeSieve[0] = primeSieve[1] = false;

        for(int i = 2; i <= end; i++) {
            if(primeSieve[i]) {
                for(int j = i*i; j <= end; j = j + i)
                    primeSieve[j] = false;
            }
            primeCount[i] = primeCount[i-1] + (primeSieve[i] ? 1 : 0);
        }

        return primeCount[end] - primeCount[start-1];
    }
}